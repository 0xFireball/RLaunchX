using Newtonsoft.Json;

namespace RLaunchX.Types
{
    public class RLaunchConfiguration
    {
        [JsonProperty("applications")]
        public AppLaunchParameters[] Applications { get; set; }
    }
}