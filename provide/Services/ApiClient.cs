using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using provide.Model;

namespace provide
{
    public class ApiClient
    {
        private static readonly HttpClient client;

        static ApiClient() {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("user-agent", "provide dotnet API client");
        }

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

        public async Task<T> Get<T>(string uri, Dictionary<string, object> args) {
            return await this.sendRequest<T>("GET", buildUrl(uri), args);
        }

        public async Task<T> Post<T>(string uri, BaseModel model) {
            return await this.sendRequest<T>("POST", buildUrl(uri), model);
        }

        public async Task<T> Put<T>(string uri, BaseModel model) {
            return await this.sendRequest<T>("PUT", buildUrl(uri), model);
        }

        public async Task<T> Patch<T>(string uri, BaseModel model) {
            return await this.sendRequest<T>("PATCH", buildUrl(uri), model);
        }

        public async Task<T> Delete<T>(string uri) {
            return await this.sendRequest<T>("DELETE", buildUrl(uri), null);
        }

        public override string ToString() {
            return string.Format("provide.ApiClient {0}://{1}{2}", this.scheme, this.host, this.path);
        }

        private async Task<T> sendRequest<T>(string method, string url, BaseModel model, Dictionary<string, object> query = null) {
            var uri = new UriBuilder(url);
            var req = this.createRequestMessage(method, uri, model, query);

            HttpResponseMessage res = null;
            HttpContent content = null;

            try {
                res = await client.SendAsync(req);
                content = res.Content;
                res.EnsureSuccessStatusCode();
                var raw = await content.ReadAsByteArrayAsync();
                var str = System.Text.Encoding.Default.GetString(raw);

                return JsonConvert.DeserializeObject<T>(str);
            }
            catch (Exception e) {
                System.Diagnostics.Debug.WriteLine("Failed to complete API {0} request to {1}; {2}", method, uri.ToString(), e);

                // TODO: is this neccessary?
                if (content == null) {
                    return default(T);
                }

                if (res != null) {
                    await this.throwErrorException(content, res.StatusCode);
                }
            } finally {
                // if (content != null) {
                //     content.Dispose();
                // }
            }

            return default(T);
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

        private HttpRequestMessage createRequestMessage(string method, UriBuilder uri, BaseModel model, Dictionary<string, object> query = null) {
            var mthd = method.ToUpper();

            if (mthd == "GET" && query != null) {
                uri.Query = string.Join("&", query.Select(kvp => string.Format("{0}={1}", kvp.Key, kvp.Value)));
            }

            var req = new HttpRequestMessage(new HttpMethod(mthd), uri.ToString());
            if (token != null) {
                req.Headers.Authorization = new AuthenticationHeaderValue("bearer", token);
            }

            var serializedObj = this.serializeObject(model);

            if (mthd == "POST" || mthd == "PUT" || mthd == "PATCH") {
                req.Content = new StringContent(serializedObj, Encoding.UTF8, "application/json");
            }

            return req;
        }

        private string serializeObject(BaseModel model) {
            return JsonConvert.SerializeObject(model, new JsonSerializerSettings {
                ContractResolver = new DefaultContractResolver {
                    NamingStrategy = new SnakeCaseNamingStrategy(),
                },
                Formatting = Formatting.Indented
            });
        }

        private async Task throwErrorException(HttpContent content, HttpStatusCode statusCode) {
            var raw = await content.ReadAsByteArrayAsync();
            var str = System.Text.Encoding.Default.GetString(raw);
            throw new Exception(str);
        }
    }
}
