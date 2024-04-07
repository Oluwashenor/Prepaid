using Prepaid.Client.Domain.APIModels;
using Refit;
using static Prepaid.Client.Domain.APIModels.APIModels;

namespace Prepaid.Client.Services.Interfaces
{
    public interface IBackendHttpClient
    {
        [Post("/api/User/login")]
        Task<GeneralResponse> LoginAsync([Body] LoginDTO user);
    }
}
