namespace Prepaid.Client.Domain.APIModels
{
    public class APIModels
    {
        public record GeneralResponse(bool Status, string Message = null);

    }
}
