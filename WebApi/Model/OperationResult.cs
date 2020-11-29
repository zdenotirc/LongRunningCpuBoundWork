namespace WebApi.Model
{
    public class OperationResult
    {
        public int OperationId { get; }

        public OperationResult(int operationId)
        {
            OperationId = operationId;
        }
    }
}