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
        public async void TestSingMessage() 
        {
            var token = await this.CreateIdentForTestUser();
            var vlt = Vault.InitVault(token);
            
            provide.Model.Vault.Vault vault = await vlt.CreateVault(
                new provide.Model.Vault.Vault 
                {
                    Name = "TestVault"
                });

            provide.Model.Vault.Key key = await vlt.CreateVaultKey(
                vault.Id.ToString(), 
                new Key 
                { 
                    Name = "TestKey",
                    Spec = "TestSpec",
                    Type = "asymmetric",
                    PublicKey = @"-----BEGIN PUBLIC KEY-----
                                  MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgHXYDrWFEdMNJs2VJ8oKd22esreh
                                  byWApqdGZjBn5K+vWcEcFfU4ImVJZFnik3ZiXfrz1esWLD9nvorXeqoXuut1MfZX
                                  RUYMeZfzjZDL8J16mtWyyD85MH7RD/CrlVsnG8IGS917mjB6LHkeigjyOFHsCLPM
                                  ODupQq0UWOz04c0tAgMBAAE=
                                  -----END PUBLIC KEY-----"
                });
            
            var signedMessage = await vlt.SignMessage(vault.Id.ToString(), key.Name, "message to be signed");
            Assert.NotNull(signedMessage);
        }
    }
}
