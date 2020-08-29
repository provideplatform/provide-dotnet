using provide.Model.Ident;
using System.Threading.Tasks;
using Xunit;

namespace provide.tests
{
    public class NChainTest
    {
        private async Task<string> CreateIdentForTestUser()
        {
            var authResponse = await Ident.Authenticate(
                new Auth 
                { 
                    Email = "user@prvd.local",
                    Password = "testp455"
                });
            var ident = new Ident(authResponse.Token.Token);
            return authResponse.Token.Token;
        }

        [Fact]
        public async void TestNChain() 
        {
            var token = await CreateIdentForTestUser();
            var nchain = new NChain(token);

            
        }
    }
}
