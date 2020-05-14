using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace provide
{
    public class Baseline
    {
        const string CONNECTOR_TYPE_INVALID_MESSAGE = "Invalid Goldmine connector type -- only the 'baseline' connector is supported";
        const string CONNECTOR_UNRESOLVED_MESSAGE = "Unable to resolve Goldmine connector without a configured GOLDMINE_CONNECTOR_ID environment variable or a connector_id within the signed JWT app claims";
        const string CONNECTOR_ID_ENVIRONMENT_VAR = "GOLDMINE_CONNECTOR_ID";

        private Ident ident;
        private Goldmine goldmine;
        private string connectorID;

        public Baseline(string token) {
            this.ident = new Ident(token);
            this.goldmine = new Goldmine(token);
            this.resolveConnector(token);
        }

        private void resolveConnector(string token) {
            this.connectorID = Environment.GetEnvironmentVariable(CONNECTOR_ID_ENVIRONMENT_VAR);

            var jwtHandler = new JwtSecurityTokenHandler();
            var jwt = jwtHandler.ReadToken(token) as JwtSecurityToken;
            foreach (var claim in jwt.Claims) {
                var prvd = claim.Value;
                if (claim.Type.Equals("prvd")) {
                    try {
                        var prvdClaim = JsonConvert.DeserializeObject<Dictionary<string, string>>(claim.Value);
                        this.connectorID = prvdClaim["connector_id"].ToString();
                        System.Diagnostics.Debug.WriteLine("Resolved connector id from signed JWT claims: {0}", this.connectorID);
                    } catch (Exception e) {
                        System.Diagnostics.Debug.WriteLine("Failed to parse prvd JWT claim; {0}", e);
                    }
                }
            }

            if (this.connectorID == null) {
                throw new ApplicationException(CONNECTOR_UNRESOLVED_MESSAGE);
            }

            var task = this.goldmine.GetConnectorDetails(this.connectorID, new Dictionary<string, object> {});
            var awaiter = task.GetAwaiter();
            task.Wait();

            var connector = awaiter.GetResult();
            if (connector.Item1 == 200 && connector.Item2 != null) {
                var resp = JsonConvert.DeserializeObject<Dictionary<string, object>>(connector.Item2);
                var connectorType = resp["type"];
                if (connectorType == null || !connectorType.Equals("baseline")) {
                    throw new ApplicationException(CONNECTOR_TYPE_INVALID_MESSAGE);
                }
                System.Diagnostics.Debug.WriteLine("Resolved valid baseline api connector: {0}", this.connectorID);
            } else {
                System.Diagnostics.Debug.WriteLine("Failed to fetch connector: {0}; status: {1}", this.connectorID, connector.Item1);
                throw new ApplicationException(CONNECTOR_TYPE_INVALID_MESSAGE);
            }
        }

        // CreateAgreement creates a new agreement and sends it to the named recipients; a witness is calculated
        // using a generic zkSNARK agreement circuit at this time but a specific circuit may be specified in the future.
        public async Task<(int, string)> CreateAgreement(Dictionary<string, object> args, string[] recipients) {
            return await this.goldmine.CreateConnectedEntity(this.connectorID, new Dictionary<string, object> {
                { "payload", args },
                { "recipients", recipients }
            });
        }

        // UpdateAgreement attempts to updates an in-progress Baseline agreement.
        public async Task<(int, string)> UpdateAgreement(string entityID, Dictionary<string, object> args) {
            return await this.goldmine.UpdateConnectedEntity(this.connectorID, entityID, args);
        }

        // GetAgreement retrieves a specific Baseline agreement by id.
        public async Task<(int, string)> GetAgreement(string entityID, Dictionary<string, object> args) {
            return await this.goldmine.GetConnectedEntityDetails(this.connectorID, entityID, args);
        }

        // ListAgreements retrieves a list of in-progress or previously completed Baseline agreement instances
        // which match the given query params.
        public async Task<(int, string)> ListAgreements(Dictionary<string, object> args) {
            return await this.goldmine.ListConnectedEntities(this.connectorID, args);
        }
    }
}
