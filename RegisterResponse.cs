using Newtonsoft.Json;

namespace SerializeJsonDemo
{
    public class RegisterResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
