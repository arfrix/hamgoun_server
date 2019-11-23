using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HamgoonAPIV1.Services.RocketChat
{
    public class RocketChatService: IRocketChatService
    {
        private IHttpClientFactory _clientFactory;
        public RocketChatService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<RocketIdentityPayload> Login(string username, string password)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://193.176.241.61:3000/api/v1/login")
            };
            var pairs = new List<KeyValuePair<string, string>>
            {
                KeyValuePair.Create<string, string>("user", username),
                KeyValuePair.Create<string, string>("password", password)
            }; 
            request.Content = new FormUrlEncodedContent(pairs);
            var client = _clientFactory.CreateClient();
            var resp = await client.SendAsync(request);
            if (!resp.IsSuccessStatusCode)
            {
                throw new RocketChatLoginFailed(resp.ReasonPhrase);
            }

            var rocketLoginResponse = RocketLoginResponse.FromJson(await resp.Content.ReadAsStringAsync());
            return new RocketIdentityPayload
            {
                AuthToken = rocketLoginResponse.Data.AuthToken
            };
        }

        public async Task<RocketIdentityPayload> Register(string username, string email, string pass, string name)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://193.176.241.61:3000/api/v1/users.register")
            };
            var client = _clientFactory.CreateClient();
            var pairs = new List<KeyValuePair<string, string>>
            {
                KeyValuePair.Create<string, string>("user", username),
                KeyValuePair.Create<string, string>("password", pass),
                KeyValuePair.Create<string, string>("email", email),
                KeyValuePair.Create<string, string>("name", name),
            };
            request.Content = new FormUrlEncodedContent(pairs);
            var resp = await client.SendAsync(request);
            var rocketRegisterResponse =  RocketRegisterResponse.FromJson(await resp.Content.ReadAsStringAsync());
            if (!resp.IsSuccessStatusCode)
            {
                throw new RocketChatLoginFailed(resp.StatusCode.ToString());
            }

            return await this.Login(username, pass);
        }
    }
}