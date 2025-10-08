using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HMI.Services
{
    public class FanService
    {
        private readonly HttpClient _httpClient;

        public FanService()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };
        }

        public async Task StartFanAsync() =>
            await _httpClient.PostAsync("/start", null);

        public async Task StopFanAsync() =>
            await _httpClient.PostAsync("/stop", null);

        public async Task SetSpeedAsync(decimal speed) =>
            await _httpClient.PostAsJsonAsync("/speed", new { speed });

        public async Task<FanStatus?> GetStatusAsync() =>
            await _httpClient.GetFromJsonAsync<FanStatus>("/status");
    }

    public class FanStatus
    {
        public bool IsRunning { get; set; }
        public decimal CurrentSpeed { get; set; }
    }
}
