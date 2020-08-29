using provide.Model.Ident;

namespace provide.Model.Client
{
    public class ApplicationResponse
    {
        public Application Application { get; set; } 
        public JWTToken Token { get; set; }    
    }
}
