using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace KoenZomers.UniFi.Api.Tests.Fakes
{
    public class FakeHttpUtility : IHttpUtility
    {
        public TimeSpan RespondDelay { get; set; } = TimeSpan.FromMilliseconds(1);
        public bool FailAuthenticate { get; set; }
        public bool BadAuthenticate { get; set; }

        public async Task<string> AuthenticateViaJsonPostMethod(Uri url, string username, string password, CookieContainer cookieContainer, int timeout = 60000)
        {
            await Task.Delay(RespondDelay);

            if (BadAuthenticate)
            {
                return null;
            }

            if (FailAuthenticate)
            {
                return JsonConvert.SerializeObject(new { meta = new { rc = "bad" } });
            }

            return JsonConvert.SerializeObject(new { meta = new { rc = "ok" } });
        }

        public void DisableSslValidation()
        {
            throw new NotImplementedException();
        }

        public void EnableTls11and12()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRequestResult(Uri url, CookieContainer cookieContainer, int timeout = 60000)
        {
            throw new NotImplementedException();
        }

        public Task<string> LogoutViaJsonPostMethod(Uri url, CookieContainer cookieContainer, int timeout = 60000)
        {
            throw new NotImplementedException();
        }

        public Task<string> PostRequest(Uri url, string postData, CookieContainer cookieContainer, int timeout = 60000)
        {
            throw new NotImplementedException();
        }
    }
}
