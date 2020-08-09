using System.Collections.Generic;

namespace provide.Model.Ident
{
    public class Application: BaseModel
    {
        public string NetworkId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // check config
        public Dictionary<string, object> Config { get; set; }
        public bool? Hidden { get; set; }
        public Organization[] Organizations { get; set; }
    }
}
