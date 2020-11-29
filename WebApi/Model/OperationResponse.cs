namespace WebApi.Model
{
    public class OperationResponse
    {
        public string Text { get; }

        public OperationResponse(string text)
        {
            Text = text;
        }
    }
}