using Microsoft.JSInterop;
using Prepaid.Client.Services.Interfaces;

namespace Prepaid.Client.Services.Implementation
{
    public class ClipboardService : IClipboardService
    {
        private readonly IJSRuntime _jsInterop;

        public ClipboardService(IJSRuntime jsInterop)
        {
            _jsInterop = jsInterop;
        }

        public async Task CopyToClipboard(string text)
        {
            await _jsInterop.InvokeVoidAsync("navigator.clipboard.writeText", text);
        }
    }
}
