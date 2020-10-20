using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace provide.Model.Ident
{
    public class JWTToken : BaseModel
    {

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string AccessToken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RefreshToken { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Kid { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Scope { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string GrantType { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Audience { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Issuer { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string IssuedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiresAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? ExpiresIn { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Permissions { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Prvd { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? OrganizationId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UserId { get; set; }
    }
}
