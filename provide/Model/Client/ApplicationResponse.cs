using provide.Model.Ident;

namespace provide.Model.Client
{
    public class ApplicationResponse: ProvideResponse
    {
        public Application Application { get; set; } 
        public JWTToken Token { get; set; }    
    }
}