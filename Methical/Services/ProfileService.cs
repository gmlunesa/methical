using Methical.DTOs;
using Methical.Models;
using Methical.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Methical.Services
{
    public record Sample(int userId, int id, string title, string body);

    public record SampleRequest(string title, string body, int userId);
    public class ProfileService : IProfileService
    {
        private readonly IHttpClientFactory _httpClientFactory = null!;
        private readonly MLPlatformSettings _mlPlatform;

        public ProfileService(IHttpClientFactory httpClientFactory, IOptions<MLPlatformSettings> configuration)
        {
            _httpClientFactory = httpClientFactory;
            _mlPlatform = configuration.Value;
        }
        public async Task<Profile> GetProfileAsync(bool IsStableDiffusion)
        {
            string? httpClientName = _mlPlatform.Url;
            using (HttpClient client = _httpClientFactory.CreateClient())
            {
                client.BaseAddress = new Uri(httpClientName);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _mlPlatform.Token);

                try
                {
                    // Assign image option
                    List<string> ImageOptions = new();

                    if (IsStableDiffusion)
                    {
                        ImageOptions.Add(_mlPlatform.ImageOptions[0]);
                    }
                    else
                    {
                        ImageOptions.Add(_mlPlatform.ImageOptions[1]);
                    }

                    // Form MLPlatformRequest object
                    MLPlatformRequest mlPlatformRequest = new()
                    {
                        Data = ImageOptions.ToArray()
                    };

                    // TODO: Log requests
                    // Send POST request 
                    using HttpResponseMessage response = await client.PostAsJsonAsync<MLPlatformRequest>(_mlPlatform.Endpoint, mlPlatformRequest);

                    // Throw exception if request is not successful
                    response.EnsureSuccessStatusCode();

                    // Deserialize response
                    MLPlatformResponse? mlPlatformResponse = await response.Content.ReadFromJsonAsync<MLPlatformResponse>();

                    if (mlPlatformResponse is null)
                    {
                        throw new Exception();
                    }

                    // Decode first element of Data array (mixed type array)
                    JsonElement element = (JsonElement)mlPlatformResponse.Data[0];

                    Profile profile = new()
                    {
                        Name = mlPlatformResponse.Data[1].ToString(),
                        Location = mlPlatformResponse.Data[2].ToString(),
                        Bio = mlPlatformResponse.Data[3].ToString(),
                        PhotoBase64 = element.GetProperty("value").ToString(),
                    };

                    return profile;

                }
                catch (Exception ex)
                {
                    // TODO: Get from cache if request is unsuccessful
                    return null;
                }
            };

        }
    }
}
