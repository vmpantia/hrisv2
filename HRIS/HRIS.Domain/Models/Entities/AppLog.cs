using HRIS.Domain.Models.Enums;

namespace HRIS.Domain.Models.Entities
{
    public class AppLog
    {
        public Guid Id { get; set; }
        public string? Event { get; set; }
        public string? Url { get; set; }
        public string? Method { get; set; }
        public string Message { get; set; }
        public string? Data { get; set; }
        public AppLogType Type { get; set; }
        public DateTime LogAt { get; set; }
        public string LogBy { get; set; }

        public override string ToString()
        {
            if (this == null) 
                return string.Empty;

            return $"Id: {this.Id} \n" +
                   $"Event: {this.Event} \n" +
                   $"Url: {this.Event} \n" +
                   $"Method: {this.Method} \n" +
                   $"Message: {this.Message} \n" +
                   $"Data: {this.Data} \n" +
                   $"User: {this.LogBy}";
        }
    }
}
