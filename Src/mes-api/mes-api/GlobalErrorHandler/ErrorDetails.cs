using Newtonsoft.Json;

namespace bol.api.GlobalErrorHandler
{
    public class ErrorDetails
    {
        public int Status { get; set; }

        public string? Message { get; set; }

        public string? StatusText { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}