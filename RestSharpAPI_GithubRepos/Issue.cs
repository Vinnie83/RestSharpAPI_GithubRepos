using Newtonsoft.Json;

namespace RestSharpAPI_GithubRepos
{
    public class Issue
    {
        [JsonProperty("title")]
        public string title { get; set; } 
    }
}