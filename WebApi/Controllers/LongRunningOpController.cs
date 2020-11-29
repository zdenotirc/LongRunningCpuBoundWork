using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LongRunningOpController : ControllerBase
    {
        private readonly ILogger<LongRunningOpController> _logger;

        public LongRunningOpController(ILogger<LongRunningOpController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public OperationResponse Get()
        {
            var pendingTask = LongRunningCpuBoundWork();

            if (pendingTask.IsCompleted)
            {
                return new OperationResponse("All Operations Completed.");
            }

            return new OperationResponse("Not Completed Operations (Still running...)");
        }
        
        private async Task LongRunningCpuBoundWork()
        {
            await Task.Yield();
            
            for (int i = 0; i != 500_000; ++i)
            {
                var op = new OperationResult(i);
                
                Console.WriteLine($"Operation {op.OperationId} start.");
            }
            
            // await Task.CompletedTask;
        }
    }
}