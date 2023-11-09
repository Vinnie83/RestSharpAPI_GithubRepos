using Newtonsoft.Json;

namespace RestSharpAPI_GithubRepos
{
    public class repoDemoObject
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("node_id")]
        public string node_id { get; set; }


        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("full_name")]
        public string full_name { get; set; }


    }
}