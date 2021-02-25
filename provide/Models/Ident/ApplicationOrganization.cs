using System;
using Newtonsoft.Json;

namespace provide.Model.Ident
{
    public class ApplicationOrganization : BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid OrganizationId { get; set; }
    }
}
