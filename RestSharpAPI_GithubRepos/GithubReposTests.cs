using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;

namespace RestSharpAPI_GithubRepos
{
    public class GithubReposTests
    {

        private RestClient client;
        private RestClientOptions options;
        private const string token = "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";
        

        [SetUp]
        public void Setup()
        {
            this.options = new RestClientOptions("http://api.github.com");
            options.Authenticator = new JwtAuthenticator(token);
            this.client = new RestClient(options);

        }

        [Test]
        public void Get_RepoDemo()
        {

            var request = new RestRequest("repos/Vinnie83/RestSharpDemoProject", Method.Get);

            var response = client.Execute(request); 

            var repoDemo = JsonSerializer.Deserialize<repoDemoObject>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(repoDemo, Is.Not.Null);

            Assert.That(repoDemo.id.ToString(), Is.EqualTo("714755076"));
            Assert.That(repoDemo.node_id, Is.EqualTo("R_kgDOKppMBA"));
            Assert.That(repoDemo.name, Is.EqualTo("RestSharpDemoProject"));
            Assert.That(repoDemo.full_name, Is.EqualTo("Vinnie83/RestSharpDemoProject"));


        }

        [Test]

        public void EditIssue_RepoDemo()
        {

            var request = new RestRequest("repos/Vinnie83/RestSharpDemoProject/issues/1".ToLower());

            request.AddHeader("Authorization", $"Bearer {token}");

            Console.WriteLine("Request URL: " + client.BuildUri(request).ToString());

            var response = client.Execute(request, Method.Patch);

            Console.WriteLine(response.Content);

            var issue = JsonSerializer.Deserialize<Issue>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo (HttpStatusCode.OK));


        }
    }
}