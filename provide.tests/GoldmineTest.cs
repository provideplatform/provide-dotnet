using System.Threading.Tasks;
using provide.Model.Ident;
using Xunit;

namespace provide.tests
{
    public class GoldmineTest
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
        public async void TestGoldmine() 
        {
            var token = await CreateIdentForTestUser();
            var goldmine = new Goldmine(token);

            
        }
    }
}
