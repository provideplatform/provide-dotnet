using provide.Model.Ident;
using System;
using System.Threading.Tasks;
using Xunit;

namespace provide.tests
{
    public class NChainTest
    {
        private async Task<string> CreateIdentForTestUser()
        {
            string email = String.Format("user{0}@prvd.local", (Int32) (DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds);
            await Ident.CreateUser(new User() {
                FirstName = "Test",
                LastName = "User",
                Email = email,
                Password = "prvdp4ss",
            });

            return (await Ident.Authenticate(
                new Auth 
                {
                    Email = email,
                    Password = "prvdp4ss",
                }
            )).Token.Token;
        }

        [Fact]
        public async void TestNChain() 
        {
            var token = await CreateIdentForTestUser();
            var nchain = NChain.InitNChain(token);
        }
    }
}
