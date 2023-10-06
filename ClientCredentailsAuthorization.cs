using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiraSodaBot
{
    public class ClientCredentailsAuthorization : IAuthorizationHandler
    {
        private HttpClient _client = new HttpClient();

        public async Task<string> Authorize()
        {
            string client_id = "i5sc9akf9nb3mjrqrbd07bafeqhi9l";
            string client_secret = "p04n1geikogpu3ibutxpjik1caz7kq";
            string resultUrl = $"https://id.twitch.tv/oauth2/token?client_id={client_id}&client_secret={client_secret}&grant_type=client_credentials";
            HttpResponseMessage response = await _client.PostAsync(resultUrl, null);
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ToString();
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
