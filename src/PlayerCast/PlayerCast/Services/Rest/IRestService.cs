using System;
using System.Threading.Tasks;
using PlayerCast.Helpers;

namespace PlayerCast.Services.Rest
{
    public interface IRestService
    {
        Task<ServerResponse<TSuccess>> GetAsync<TSuccess>(string resource);
    }
}
