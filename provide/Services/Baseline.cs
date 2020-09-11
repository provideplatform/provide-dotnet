using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

using Newtonsoft.Json;
using provide.Model.NChain;

namespace provide
{
    public class Baseline
    {
        const string CONNECTOR_TYPE_INVALID_MESSAGE = "Invalid NChain connector type -- only the 'baseline' connector is supported";
        const string CONNECTOR_UNRESOLVED_MESSAGE = "Unable to resolve NChain connector without a configured NCHAIN_CONNECTOR_ID environment variable or a connector_id within the signed JWT app claims";
        const string CONNECTOR_ID_ENVIRONMENT_VAR = "NCHAIN_CONNECTOR_ID";

        private Ident ident;
        private NChain nchain;
        private string connectorID;

        public Baseline(string token) {
            this.ident = Ident.InitIdent(token);
            this.nchain =  NChain.InitNChain(token);
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

            var task = this.nchain.GetConnectorDetails(this.connectorID, new Dictionary<string, object> {});
            var awaiter = task.GetAwaiter();
            task.Wait();

            var connector = awaiter.GetResult();
            if (connector != null) {
                // FIXME: Please check this
                if (connector.Type == null || !connector.Type.Equals("baseline")) {
                    throw new ApplicationException(CONNECTOR_TYPE_INVALID_MESSAGE);
                }
                System.Diagnostics.Debug.WriteLine("Resolved valid baseline api connector: {0}", this.connectorID);
            } else {
                // this should fail in ApiClient? FIXME if needed
                System.Diagnostics.Debug.WriteLine("Failed to fetch connector: {0}; status: {1}", this.connectorID);
                throw new ApplicationException(CONNECTOR_TYPE_INVALID_MESSAGE);
            }
        }

        // CreateBusinessObject creates a new business object and sends it to the named recipients; a witness is calculated
        // using a generic zkSNARK agreement circuit at this time but a specific circuit may be specified in the future.
        public async Task<ConnectedEntity> CreateBusinessObject(ConnectedEntity entity, string[] recipients) {
            return await this.nchain.CreateConnectedEntity(this.connectorID, entity);
        }

        // UpdateBusinessObject attempts to updates an in-progress Baseline business object.
        public async Task<ConnectedEntity> UpdateBusinessObject(string entityID, ConnectedEntity entity) {
            return await this.nchain.UpdateConnectedEntity(this.connectorID, entityID, entity);
        }

        // GetBusinessObject retrieves a specific Baseline business object by id.
        public async Task<ConnectedEntity> GetBusinessObject(string entityID, Dictionary<string, object> args) {
            return await this.nchain.GetConnectedEntityDetails(this.connectorID, entityID, args);
        }

        // ListBusinessObject retrieves a list of in-progress or previously completed Baseline business object instances
        // which match the given query params.
        public async Task<List<ConnectedEntity>> ListBusinessObject(Dictionary<string, object> args) {
            return await this.nchain.ListConnectedEntities(this.connectorID, args);
        }
    }
}
