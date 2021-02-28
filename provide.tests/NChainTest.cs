using Newtonsoft.Json.Linq;
using provide.Model.Ident;
using provide.Model.NChain;
using provide.Model.Vault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace provide.tests
{
    public class NChainTest
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
        public async Task TestInitNChain()
        {
            // same way of getting compiled artifacts as in bri-1 example
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(new HttpMethod("get"), "https://s3.amazonaws.com/static.provide.services/capabilities/provide-capabilities-manifest.json");
            var res = await httpClient.SendAsync(request);
            var content = res.Content;

            var raw = await content.ReadAsByteArrayAsync();
            var str = System.Text.Encoding.Default.GetString(raw);
            var parsed = JObject.Parse(str);
            var contract = parsed["baseline"]["contracts"][2];

            var token = await CreateIdentForTestUser();
            var ident = Ident.InitIdent(token);

            // this network needs to be activated in db, at least that is done first in bri-1 example
            var ethTestNetId = "66d44f30-9092-4182-a3c4-bc02736d6ae5";
            var application = await ident.CreateApplication(new Application
            {
                Name = "test application",
                Config = new Dictionary<string, object> 
                {
                    { "baselined", true}
                },
                NetworkId = new Guid(ethTestNetId)
            });


            var accessRefreshToken = await ident.CreateToken(new JWTToken
            {
                ApplicationId = application.Id
            });

            var ident2 = new Ident(accessRefreshToken.Token);

            var nchain = NChain.InitNChain(accessRefreshToken.Token);

            await nchain.CreateAccount(new Model.NChain.Account
            {
                NetworkId = new Guid(ethTestNetId)
            });
    
            var accounts = await nchain.ListAccounts(new Dictionary<string, object>());

            await nchain.CreateContract(new Model.NChain.Contract
            {
                Address = "0x",
                Name = "Shuttle",
                NetworkId = new Guid(ethTestNetId),
                ApplicationId = application.Id,
                Params = new Dictionary<string, object>
                {
                    { "account_id", accounts[0].Id },
                    { "compiled_artifact", contract },
                    { "argv", new string[0] }
                },
                Type = "registry"
            });

            var contracts = new List<Contract>();

            while (true) {
                contracts = await nchain.ListContracts(new Dictionary<string, object> {
                { "type", "organization-registry"}
                });

                if (contracts.Count == 1 && contracts[0].Address != "0x") { break ;}


                Thread.Sleep(2000);
            }

            var organization = await ident.CreateOrganization(new Organization
            {
                Name = "test organization",
                Metadata = new Dictionary<string, object>
                {
                    { "messaging_endpoint", "localhost:4222" }
                }
            });

            var orgToken = await ident.CreateToken(new JWTToken
            {
                OrganizationId = organization.Id
            });

            var vault = Vault.InitVault(orgToken.Token);

            var vaults = new List<provide.Model.Vault.Vault>();
            while(true) {
                vaults = await vault.ListVaults(new Dictionary<string, object>());

                if (vaults.Count != 0) {
                    break;
                }
            }

            await vault.CreateVaultKey(
                vaults[0].Id.ToString(),
                new Key
                {
                    Type = "asymmetric",
                    Usage = "sign/verify",
                    Spec = "babyJubJub",
                    Name = $"{organization.Name} babyJubJub keypair",
                    Description = $"{organization.Name} babyJubJub keypair"
                }
            );

            await vault.CreateVaultKey(
                vaults[0].Id.ToString(),
                new Key
                {
                    Type = "asymmetric",
                    Usage = "sign/verify",
                    Spec = "secp256k1",
                    Name = $"{organization.Name} secp256k1 keypair",
                    Description = $"{organization.Name} secp256k1 keypair"
                }
            );

            await vault.CreateVaultKey(
                vaults[0].Id.ToString(),
                new Key
                {
                    Type = "asymmetric",
                    Usage = "sign/verify",
                    Spec = "BIP39",
                    Name = $"{organization.Name} BIP39 keypair",
                    Description = $"{organization.Name} BIP39 keypair"
                }
            );

            var keys = await vault.ListVaultKeys(vaults[0].Id.ToString(), new Dictionary<string, object>());

            var address = keys[2].Address;

            await ident2.AddApplicationOrganizations(application.Id.ToString(), new ApplicationOrganization
            {
                OrganizationId = organization.Id.Value
            });

            
            while(true)
            {
                var result = await nchain.ExecuteContract(contracts[0].Id.ToString(), new Model.NChain.Transaction
                {
                    Method = "getOrgCount",
                    Value = 0,
                    AccountId = accounts[0].Id,
                    Params = new string[0],
                });

                var result2 = await nchain.ExecuteContract(contracts[0].Id.ToString(), new Model.NChain.Transaction
                {
                    Method = "getOrg",
                    Value = 0,
                    AccountId = accounts[0].Id,
                    Params = new string[1] { address },
                });
            }
        }
    }
}
