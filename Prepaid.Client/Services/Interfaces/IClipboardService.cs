namespace Prepaid.Client.Services.Interfaces
{
    public interface IClipboardService
    {
        Task CopyToClipboard(string text);
    }
}
