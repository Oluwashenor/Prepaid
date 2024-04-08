namespace Prepaid.API.Domain.DTOs
{
    public record GeneralResponse(bool Status, string Message = null);

    public class ServiceResponse<T>{
        public bool Status { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
    }
}
