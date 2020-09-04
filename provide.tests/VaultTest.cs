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

        [Fact]
        public async void TestSingAndVerifyMessage() 
        {
            var message = "message to be signed";
            var token = await this.CreateIdentForTestUser();
            var vlt = Vault.InitVault(token);
            
            provide.Model.Vault.Vault vault = await vlt.CreateVault(
                new provide.Model.Vault.Vault 
                {
                    Name = "TestVault"
                });

            var generatedKey = await vlt.CreateVaultKey(
                vault.Id.ToString(),
                new Key 
                {
                    Type = "asymmetric",
                    Usage = "sign/verify",
                    Spec = "secp256k1",
                    Name = "TestKey",
                    Description = "Key used to test signing"
                }
            );
            
            var signedMessage = await vlt.SignMessage(vault.Id.ToString(), generatedKey.Name, message);

            Assert.NotNull(signedMessage.Signature);
            Assert.NotEmpty(signedMessage.Signature);

            var verifiedMessage = await vlt.VerifySignature(vault.Id.ToString(), generatedKey.Id.ToString(), message, signedMessage.Signature);
            
            Assert.True(verifiedMessage.Verified);
        }
    }
}
