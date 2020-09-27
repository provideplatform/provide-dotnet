using provide.Model.Vault;
using Xunit;

namespace provide.tests
{
    public class VaultTest
    {
        [Fact]
        public async void TestCreateVault() 
        {
            var token = await TestUtil.CreateIdentForTestUser();
            var vlt = Vault.InitVault(token);
            provide.Model.Vault.Vault vault = await vlt.CreateVault(new provide.Model.Vault.Vault {
                Name = "TestVault",
            });
            Assert.NotNull(vault.Id);
            Assert.Equal("TestVault", vault.Name);
        }

        [Fact]
        public async void TestCreateSecp256k1Key() 
        {
            var token = await TestUtil.CreateIdentForTestUser();
            var vlt = Vault.InitVault(token);
            provide.Model.Vault.Vault vault = await vlt.CreateVault(
                new provide.Model.Vault.Vault 
                {
                    Name = "TestVault"
                }
            );

            var key = await vlt.CreateVaultKey(
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
            Assert.NotNull(key.Id);
            Assert.NotNull(key.Address);
            Assert.Equal("secp256k1", key.Spec);
        }

        [Fact]
        public async void TestSignAndVerifyMessage() 
        {
            var message = "message to be signed";
            var token = await TestUtil.CreateIdentForTestUser();
            var vlt = Vault.InitVault(token);
            
            provide.Model.Vault.Vault vault = await vlt.CreateVault(
                new provide.Model.Vault.Vault 
                {
                    Name = "TestVault"
                }
            );

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
            
            var signedMessage = await vlt.SignMessage(vault.Id.ToString(), generatedKey.Id.ToString(), message);
            Assert.NotNull(signedMessage.Signature);
            Assert.NotEmpty(signedMessage.Signature);

            var verifiedMessage = await vlt.VerifySignature(vault.Id.ToString(), generatedKey.Id.ToString(), message, signedMessage.Signature);
            Assert.True(verifiedMessage.Verified);
        }

        [Fact]
        public async void TestCreateSecret() 
        {
            var token = await TestUtil.CreateIdentForTestUser();
            var vlt = Vault.InitVault(token);
            provide.Model.Vault.Vault vault = await vlt.CreateVault(
                new provide.Model.Vault.Vault 
                {
                    Name = "TestVault"
                }
            );

            var secret = await vlt.CreateVaultSecret(
                vault.Id.ToString(),
                new Secret 
                {
                    Type = "some arbitrary type...",
                    Name = "TestKey",
                    Description = "Key used to test signing",
                    Value = "my secret value"
                }
            );
            Assert.NotNull(secret.Id);
        }
    }
}
