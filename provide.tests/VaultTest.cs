// Copyright 2017-2022 Provide Technologies Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Collections.Generic;
using System.Text;
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
            provide.Model.Vault.Vault vault = await vlt.CreateVault(new provide.Model.Vault.Vault
            {
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
            var message = "02a285b1a277f7602dc115a3bf627a8b7603a4a1be9a72b3ab0284878afe443d"; // secp256k1 signing requests must send 32-byte `message` (ie hash the data first...)
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

            // sign and assert
            var signReq = new SignMessageRequest
            {
                Message = message,
                Options = new Dictionary<string, object>()
            };
            var signedMessage = await vlt.SignMessage(vault.Id.ToString(), generatedKey.Id.ToString(), signReq);
            Assert.NotNull(signedMessage.Signature);
            Assert.NotEmpty(signedMessage.Signature);

            // verify and assert
            var verificationReq = new SignatureVerificationRequest
            {
                Message = message,
                Signature = signedMessage.Signature,
                Options = new Dictionary<string, object>()
            };
            var verifiedMessage = await vlt.VerifySignature(vault.Id.ToString(), generatedKey.Id.ToString(), verificationReq);
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

        [Fact]
        public async void TestSignAndVerifyUsingBIP39Key()
        {
            var vlt = await TestUtil.InitVaultWithOrgToken();
            var vault = await vlt.CreateVault(new provide.Model.Vault.Vault
            {
                Name = "test vault"
            });

            var orgName = "test org";
            var hdWallet = await vlt.CreateVaultKey(vault.Id.ToString(), new Key
            {
                Type = "asymmetric",
                Usage = "sign/verify",
                Spec = "BIP39",
                Name = $"{orgName} BIP39 keypair",
                Description = $"{orgName} BIP39 keypair"
            });
            var message = "02a285b1a277f7602dc115a3bf627a8b7603a4a1be9a72b3ab0284878afe443d"; // secp256k1 signing requests must send 32-byte `message` (ie hash the data first...)

            var hdWalletReqOptions = new Dictionary<string, object>
            {
                { "coin", 60 }, // ETH
            };

            // sign and assert
            var signReq = new SignMessageRequest
            {
                Message = message,
                Options = new Dictionary<string, object> 
                {
                    { "hdwallet", hdWalletReqOptions }
                }
            };
            var signedMessage = await vlt.SignMessage(vault.Id.ToString(), hdWallet.Id.ToString(), signReq);

            Assert.NotNull(signedMessage.Signature);
            Assert.NotEmpty(signedMessage.Signature);

            // verify and assert
            var verificationReq = new SignatureVerificationRequest
            {
                Message = message,
                Signature = signedMessage.Signature,
                Options = new Dictionary<string, object> 
                {
                    { "hdwallet", hdWalletReqOptions }
                }
            };
            var verifiedMessage = await vlt.VerifySignature(vault.Id.ToString(), hdWallet.Id.ToString(), verificationReq);
            Assert.True(verifiedMessage.Verified);
        }
    }
}
