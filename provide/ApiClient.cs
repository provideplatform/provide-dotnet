using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public ApiClient(string token) {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwt = jwtHandler.ReadToken(token) as JwtSecurityToken;

            var audience = new Uri(jwt.Audiences.First());
            this.scheme = audience.Scheme;
            this.host = audience.Host;
            this.path = audience.AbsolutePath;
            if (!audience.IsDefaultPort) {
                this.host = string.Format("{0}:{1}", this.host, audience.Port);
            }

            this.token = token;
        }

        public ApiClient(string host, string path, string scheme, string token) {
            this.host = host;
            this.path = path;
            this.scheme = scheme;
            this.token = token;
        }

        public override string ToString() {
            return string.Format("provide.ApiClient {0}://{1}{2}", this.scheme, this.host, this.path);
        }

        private HttpClient buildClient() {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("user-agent", "provide dotnet API client");
            return client;
        }

        private async Task<(int, string)> sendRequest(string method, string url, Dictionary<string, object> args) {
            var client = buildClient();
            var uri = new UriBuilder(url);
            var mthd = method.ToUpper();

            if (mthd == "GET" && args != null) {
                uri.Query = string.Join("&", args.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));
            }

            var req = new HttpRequestMessage(new HttpMethod(mthd), uri.ToString());

            if (token != null) {
                req.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
            }

            if (mthd == "POST" || mthd == "PUT") {
                req.Content = new StringContent(JsonConvert.SerializeObject(args), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage res = null;
            HttpContent content = null;

            try {
                res = await client.SendAsync(req);
                content = res.Content;
                res.EnsureSuccessStatusCode();
                var raw = await content.ReadAsByteArrayAsync();
                var str = System.Text.Encoding.Default.GetString(raw);
                return ((int) res.StatusCode, str);
            } catch (Exception e) {
                System.Diagnostics.Debug.WriteLine("Failed to complete API {0} request to {1}; {2}", method, uri.ToString(), e);

                if (res != null) {
                    byte[] raw;
                    if (content != null) {
                        raw = await content.ReadAsByteArrayAsync();
                        var str = System.Text.Encoding.Default.GetString(raw);
                        return ((int) res.StatusCode, str);
                    }
                    return ((int) res.StatusCode, null);
                }
            } finally {
                if (content != null) {
                    content.Dispose();
                }
            }

            return (-1, null);
        }

        public async Task<(int, string)> Get(string uri, Dictionary<string, object> args) {
            return await this.sendRequest("GET", buildUrl(uri), args);
        }

        public async Task<(int, string)> Post(string uri, Dictionary<string, object> args) {
            return await this.sendRequest("POST", buildUrl(uri), args);
        }

        public async Task<(int, string)> Put(string uri, Dictionary<string, object> args) {
            return await this.sendRequest("PUT", buildUrl(uri), args);
        }

        public async Task<(int, string)> Delete(string uri) {
            return await this.sendRequest("DELETE", buildUrl(uri), null);
        }

        private string buildUrl(string uri) {
            return String.Format(
                "{0}://{1}/{2}/{3}",
                this.scheme,
                this.host,
                this.path.TrimStart('/').TrimEnd('/'),
                uri.TrimStart('/').TrimEnd('/')
            );
        }
    }
}
