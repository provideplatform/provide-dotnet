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
                        var connectorID = prvdClaim["connector_id"].ToString();

                        var task = this.goldmine.GetConnectorDetails(this.connectorID, new Dictionary<string, object> {});
                        var awaiter = task.GetAwaiter();
                        task.Wait();

                        var connector = awaiter.GetResult();
                        if (connector.Item1 == 200) {
                            this.connectorID = connectorID;

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

        // InitProtocol initiates the Baseline protocol using the Provide<>Baseline proxy connector,
        // computing a witness using a generic zkSNARK circuit.
        public async Task<(int, object)> InitProtocol(Dictionary<string, object> args) {
            return await this.goldmine.CreateConnectedEntity(this.connectorID, args);
        }

        // ContinueProtocol interacts with an in-progress instance of the Baseline protocol using the
        // Provide<>Baseline proxy connector.
        public async Task<(int, object)> ContinueProtocol(string entityID, Dictionary<string, object> args) {
            return await this.goldmine.UpdateConnectedEntity(this.connectorID, entityID, args);
        }

        // GetProtocol retrieves the latest state of an in-progress or previously-completed instance of
        // the Baseline protocol.
        public async Task<(int, object)> GetProtocol(string entityID, Dictionary<string, object> args) {
            return await this.goldmine.GetConnectedEntityDetails(this.connectorID, entityID, args);
        }
    }
}
