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
    public class SlowOpController : ControllerBase
    {
        private readonly ILogger<LongRunningOpController> _logger;

        public SlowOpController(ILogger<LongRunningOpController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public OperationResponse GetSlowOp()
        {
            // Simulate slow op
            Thread.Sleep(2000);
            
            return new OperationResponse("Slow Operation Completed.");
        }
        
        [HttpGet("SlowOpAsync")]
        public async Task<OperationResponse> GetSlowOpAsync()
        {
            // Simulate slow async operation
            await Task.Delay(2000);
            
            return new OperationResponse("Slow Async Operation Completed.");
        }
    }
}