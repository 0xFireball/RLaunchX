using Newtonsoft.Json;

namespace RLaunchX.Types
{
    public class AppLaunchParameters
    {
        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("args")]
        public string[] Arguments { get; set; }
    }
}