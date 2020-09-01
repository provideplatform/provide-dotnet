using provide.Model.Ident;
using provide.Model.Vault;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace provide.tests
{
    public class VaultTest
    {
        private async Task<string> CreateIdentForTestUser()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string username = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            string email = String.Format("user{0}@prvd.local", username);

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
        public async void TestCreateVault() 
        {
            var token = await this.CreateIdentForTestUser();
            var vlt = Vault.InitVault(token);
            provide.Model.Vault.Vault vault = await vlt.CreateVault(new provide.Model.Vault.Vault {
                Name = "TestVault",
            });
            Assert.NotNull(vault.Id);
            Assert.Equal("TestVault", vault.Name);
        }
    }
}
