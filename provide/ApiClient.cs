using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace provide
{
    public class ApiClient
    {
        private string host;
        private string path;
        private string scheme;
        private string token;

        public ApiClient(string host, string path, string scheme, string token) {
            this.host = host;
            this.path = path;
            this.scheme = scheme;
            this.token = token;
        }

        private HttpClient buildClient() {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("user-agent", "provide dotnet API client");
            return client;
        }

        private async Task<(int, object)> sendRequest(string method, string url, Dictionary<string, object> args) {
            var client = buildClient();
            var uri = new UriBuilder(url);
            var mthd = method.ToUpper();

            if (mthd == "GET" && args != null) {
                uri.Query = string.Join("&", args.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));
            }

            var req = new HttpRequestMessage(new HttpMethod(mthd), uri.ToString());

            if (token != null) {
                req.Headers.Authorization = new AuthenticationHeaderValue(String.Format("bearer {0}", token));
            }

            if (mthd == "POST" || mthd == "PUT") {
                req.Headers.Add("content-type", "application/json");
            }

            try {
                var res = await client.SendAsync(req);
                res.EnsureSuccessStatusCode();
                var resp = JsonConvert.DeserializeObject(res.Content.ToString());
                return ((int) res.StatusCode, resp);
            } catch (Exception e) {
                System.Diagnostics.Debug.WriteLine("Failed to send API request to {0}; {1}", uri.ToString(), e);
            }

            return (-1, null);
        }

        public async Task<(int, object)> Get(string uri, Dictionary<string, object> args) {
            return await sendRequest("GET", buildUrl(uri), args);
        }

        public async Task<(int, object)> Post(string uri, Dictionary<string, object> args) {
            return await sendRequest("POST", buildUrl(uri), args);
        }

        public async Task<(int, object)> Put(string uri, Dictionary<string, object> args) {
            return await sendRequest("PUT", buildUrl(uri), args);
        }

        public async Task<(int, object)> Delete(string uri) {
            return await sendRequest("DELETE", buildUrl(uri), null);
        }

        private string buildUrl(string uri) {
            return String.Format("{0}://{1}/{2}/{3}", scheme, host, path, uri);
        }
    }
}
