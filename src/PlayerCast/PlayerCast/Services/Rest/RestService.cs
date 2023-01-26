using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using PlayerCast.Helpers;

namespace PlayerCast.Services.Rest
{
    public class RestService : IRestService
    {
        #region -- IRestService implementation --

        public Task<ServerResponse<TSuccess>> GetAsync<TSuccess>(string resource)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(resource)
            };

            return SendRequest<TSuccess>(request);
        }

        #endregion

        #region -- Private helpers --

        private async Task<ServerResponse<TSuccess>> SendRequest<TSuccess>(HttpRequestMessage request)
        {
            var result = new ServerResponse<TSuccess>();

            using (var client = new HttpClient())
            using (var response = await client.SendAsync(request).ConfigureAwait(false))
            {
                var responseString = await response.Content.ReadAsStringAsync();

                result.Code = (int)response.StatusCode;
                result.IsSuccess = result.Code == 200;

                if (response.IsSuccessStatusCode)
                {
                    result.SuccessResult = JsonSerializer.Deserialize<TSuccess>(responseString);
                }
            }

            return result;
        }

        #endregion
    }
}
