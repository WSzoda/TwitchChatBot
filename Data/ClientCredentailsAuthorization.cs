

using Microsoft.Extensions.Configuration;

namespace ShiraSodaBot.Data
{
    public class ClientCredentailsAuthorization : IAuthorizationHandler
    {
        private HttpClient _client = new HttpClient();

        private readonly IConfiguration _config;

        public ClientCredentailsAuthorization(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> Authorize()
        {
            string client_id = _config["ApiSettings:client_id"];
            string client_secret = _config["ApiSettings:secret_id"];
            string resultUrl = $"https://id.twitch.tv/oauth2/token?client_id={client_id}&client_secret={client_secret}&grant_type=client_credentials";
            HttpResponseMessage response = await _client.PostAsync(resultUrl, null);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }

        public Task<string> Renew()
        {
            throw new NotImplementedException();
        }
    }
}
