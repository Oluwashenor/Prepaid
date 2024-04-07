using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Prepaid.Client;
using Prepaid.Client.Services.Implementation;
using Prepaid.Client.Services.Interfaces;
using Syncfusion.Blazor.Popups;
using Syncfusion.Blazor;
using Refit;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IClipboardService, ClipboardService>();

builder.Services.AddRefitClient<IBackendHttpClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7053"));

builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<SfDialogService>();

await builder.Build().RunAsync();
