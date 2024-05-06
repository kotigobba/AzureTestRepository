using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using NorthwindModelClassLibrary;
using System.Reflection;
using System.Text.Json;

namespace NorthwindTradersWebApp.Infrastructure
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
        Task<UserModel> GetUserModel(int userId, string token);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly ApiConfigurations _apiConfigs;
        public AuthenticationService(
            IOptions<ApiConfigurations> apiConfigs
            )
        {
            _apiConfigs = apiConfigs.Value;
        }

        public async Task<AuthenticationResponse> Authenticate(AuthenticationRequest model)
        {
            var serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields=true
            };
            var jsonContent = JsonContent.Create<AuthenticationRequest>(
                inputValue: model,
                mediaType: new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"),
                options: serializerOptions
            );
            using HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_apiConfigs.AuthBaseUrl);
            
            var response=await client.PostAsync(_apiConfigs.AuthenticateUrl, jsonContent);
            response.EnsureSuccessStatusCode(); 
            var result = await response.Content.ReadFromJsonAsync<AuthenticationResponse>();
           
            return result!;
        }

        public async Task<UserModel> GetUserModel(int userId, string token)
        {
            //using HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(_apiConfigs.AuthBaseUrl);
            //client.DefaultRequestHeaders.Add("Authorization", )
            //var response = await client.GetAsync($"{_apiConfigs.AuthenticateUrl}/{userId}");
            //response.EnsureSuccessStatusCode();
            //var result = await response.Content.ReadFromJsonAsync<UserModel>();
            var result = await ApiHelper.ExecuteHttpGet<UserModel>(
                url: $"{_apiConfigs.AuthenticateUrl}/validate",
                token: token,
                baseUrl: _apiConfigs.AuthBaseUrl
                );
            return result!;
        }
    }
}
