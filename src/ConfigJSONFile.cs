using Newtonsoft.Json;

namespace DiscordBot
{
   //get the token and prefix strings in the JSON file
   public struct ConfigJSONTokenPrefix
    {
        [JsonProperty("token")]
        public string Token
        {
            get;
            private set;
        }

        [JsonProperty("prefix")]
        public string Prefix
        {
            get;
            private set;
        }
    }
}
