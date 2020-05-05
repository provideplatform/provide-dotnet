using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace provide
{
    public class Baseline
    {
        private Ident ident;
        private Goldmine goldmine;
        private string connectorID;

        public Baseline(string token) {
            this.ident = new Ident(token);
            this.goldmine = new Goldmine(token);
            this.resolveConnector(token);
        }

        private void resolveConnector(string token) {
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwt = jwtHandler.ReadToken(token) as JwtSecurityToken;
            foreach (var claim in jwt.Claims) {
                var prvd = claim.Value;
                if (claim.Type.Equals("prvd")) {
                    try {
                        var prvdClaim = JsonConvert.DeserializeObject<Dictionary<string, string>>(claim.Value);
                        this.connectorID = prvdClaim["connector_id"].ToString();

                        var task = this.goldmine.GetConnectorDetails(this.connectorID, new Dictionary<string, object> {});
                        var awaiter = task.GetAwaiter();
                        task.Wait();

                        var connector = awaiter.GetResult();
                        if (connector.Item1 == 200) {
                            // FIXME-- parse connector response and verify it is a baseline connector...
                        } else {
                            System.Diagnostics.Debug.WriteLine("Failed to fetch connector; {0}", connectorID);
                        }
                    } catch (Exception e) {
                        System.Diagnostics.Debug.WriteLine("Failed to parse prvd JWT claim; {0}", e);
                    }
                }
            }
        }

        // CreateAgreement creates a new agreement and sends it to the named recipients; a witness is calculated
        // using a generic zkSNARK agreement circuit at this time but a specific circuit may be specified in the future.
        public async Task<(int, object)> CreateAgreement(Dictionary<string, object> args, string[] recipients) {
            return await this.goldmine.CreateConnectedEntity(this.connectorID, new Dictionary<string, object> {
                { "payload", args },
                { "recipients", recipients }
            });
        }

        // UpdateAgreement attempts to updates an in-progress Baseline agreement.
        public async Task<(int, object)> UpdateAgreement(string entityID, Dictionary<string, object> args) {
            return await this.goldmine.UpdateConnectedEntity(this.connectorID, entityID, args);
        }

        // GetAgreement retrieves a specific Baseline agreement by id.
        public async Task<(int, object)> GetAgreement(string entityID, Dictionary<string, object> args) {
            return await this.goldmine.GetConnectedEntityDetails(this.connectorID, entityID, args);
        }

        // ListAgreements retrieves a list of in-progress or previously completed Baseline agreement instances
        // which match the given query params.
        public async Task<(int, object)> ListAgreenments(Dictionary<string, object> args) {
            return await this.goldmine.ListConnectedEntities(this.connectorID, args);
        }
    }
}
