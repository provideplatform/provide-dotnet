using Newtonsoft.Json.Linq;
using provide.Model.Ident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

            await Ident.CreateUser(new User()
            {
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

            var organization = await ident.CreateOrganization(new Organization
            {
                Name = "test organization"
            });

            var application = await ident.CreateApplication(new Application
            {
                Name = "test application",
            });

            var accessRefreshToken = await ident.CreateToken(new JWTToken
            {
                Scope = "offline_access",
                ApplicationId = application.Id
            });

            ident = new Ident(accessRefreshToken.AccessToken);
            
            // FEEDBACK NEEDED: Do we need something else to add orgs to org registry?
            // how do we get org address to id org in contract?
            await ident.AddApplicationOrganizations(application.Id.ToString(), new ApplicationOrganization
            {
                OrganizationId = organization.Id.Value
            });

            // this network needs to be activated in db, at least that is done first in bri-1 example
            var ethTestNetId = "66d44f30-9092-4182-a3c4-bc02736d6ae5";
            var nchain = NChain.InitNChain(accessRefreshToken.AccessToken);

            await nchain.CreateAccount(new Model.NChain.Account
            {
                NetworkId = new Guid(ethTestNetId),
            });
            var accounts = await nchain.ListAccounts(new Dictionary<string, object>());

            await nchain.CreateContract(new Model.NChain.Contract
            {
                Address = "0x",
                Name = "OrgRegistry",
                NetworkId = new Guid(ethTestNetId),
                ApplicationId = application.Id,
                Params = new Dictionary<string, object>
                {
                    { "account_id", accounts[0].Id },
                    { "compiled_artifact", contract }
                },
                Type = "organization-registry"
            });

            var contracts = await nchain.ListContracts(new Dictionary<string, object>
            {
                { "type", "organization-registry"}
            });

            // FEEDBACK NEEDED: this is returning broadcast tx result, but this is a read method, it should return result?
            // {
                // "confidence": null,
                // "ref": "d6562b9f-fe2d-4405-a1ae-fdb316cf94ee"
            // }

            // FEEDBACK NEEDED: Do we have example on format of Transaction here, what we have is not in lines with docs
            await nchain.ExecuteContract(contracts[0].Id.ToString(), new Model.NChain.Transaction
            {
                Method = "getOrgCount",
                Value = 0,
                AccountId = accounts[0].Id,
            });
        }
    }
}
