using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace provide
{
    public class NChain: ApiClient
    {
        public NChain(string token) : base(token) {}

        public NChain InitNChain(string token) {
            return new NChain(token);
        }

        // CreateAccount
        public async Task<(int, string)> CreateAccount(Dictionary<string, object> args) {
            return await this.Post("accounts", args);
        }

        // ListAccounts
        public async Task<(int, string)> ListAccounts(Dictionary<string, object> args) {
            return await this.Get("accounts", args);
        }

        // GetAccountDetails
        public async Task<(int, string)> GetAccountDetails(string accountID, Dictionary<string, object> args) {
            var uri = String.Format("accounts/{0}", accountID);
            return await this.Get(uri, args);
        }

        // GetAccountBalance
        public async Task<(int, string)> GetAccountBalance(string accountID, string tokenID, Dictionary<string, object> args) {
            var uri = String.Format("accounts/{0}/balances/{1}", accountID, tokenID);
            return await this.Get(uri, args);
        }

        // CreateBridge
        public async Task<(int, string)> CreateBridge(Dictionary<string, object> args) {
            return await this.Post("bridges", args);
        }

        // ListBridges
        public async Task<(int, string)> ListBridges(Dictionary<string, object> args) {
            return await this.Get("bridges", args);
        }

        // GetBridgeDetails
        public async Task<(int, string)> GetBridgeDetails(string bridgeID, Dictionary<string, object> args) {
            var uri = String.Format("bridges/{0}", bridgeID);
            return await this.Get(uri, args);
        }

        // CreateConnector
        public async Task<(int, string)> CreateConnector(Dictionary<string, object> args) {
            return await this.Post("connectors", args);
        }

        // ListConnectors
        public async Task<(int, string)> ListConnectors(Dictionary<string, object> args) {
            return await this.Get("connectors", args);
        }

        // GetConnectorDetails
        public async Task<(int, string)> GetConnectorDetails(string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}", connectorID);
            return await this.Get(uri, args);
        }

        // DeleteConnector
        public async Task<(int, string)> DeleteConnector(string connectorID) {
            var uri = String.Format("connectors/{0}", connectorID);
            return await this.Delete(uri);
        }

        // ListConnectedEntities -- invokes the configured connector proxy in a RESTful manner -- i.e., GET /
        public async Task<(int, string)> ListConnectedEntities(string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities", connectorID);
            return await this.Get(uri, args);
        }

        // GetConnectedEntityDetails -- invokes the configured connector proxy in a RESTful manner -- i.e., GET /:id
        public async Task<(int, string)> GetConnectedEntityDetails(string connectorID, string entityID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await this.Get(uri, args);
        }

        // CreateConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., POST /
        public async Task<(int, string)> CreateConnectedEntity(string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities", connectorID);
            return await this.Post(uri, args);
        }

        // UpdateConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., PUT /:id
        public async Task<(int, string)> UpdateConnectedEntity(string connectorID, string entityID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await this.Put(uri, args);
        }

        // DeleteConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., DELETE /:id
        public async Task<(int, string)> DeleteConnectedEntity(string connectorID, string entityID) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await this.Delete(uri);
        }

        // CreateContract
        public async Task<(int, string)> CreateContract(Dictionary<string, object> args) {
            return await this.Post("contracts", args);
        }

        // ExecuteContract
        public async Task<(int, string)> ExecuteContract(string contractID, Dictionary<string, object> args) {
            var uri = String.Format("contracts/{0}/execute", contractID);
            return await this.Post(uri, args);
        }

        // ListContracts
        public async Task<(int, string)> ListContracts(Dictionary<string, object> args) {
            return await this.Get("contracts", args);
        }

        // GetContractDetails
        public async Task<(int, string)> GetContractDetails(string contractID, Dictionary<string, object> args) {
            var uri = String.Format("contracts/{0}", contractID);
            return await this.Get(uri, args);
        }

        // CreateNetwork
        public async Task<(int, string)> CreateNetwork(Dictionary<string, object> args) {
            return await this.Post("networks", args);
        }

        // UpdateNetwork updates an existing network
        public async Task<(int, string)> UpdateNetwork(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}", networkID);
            return await this.Put(uri, args);
        }

        // ListNetworks
        public async Task<(int, string)> ListNetworks(Dictionary<string, object> args) {
            return await this.Get("networks", args);
        }

        // GetNetworkDetails
        public async Task<(int, string)> GetNetworkDetails(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkAccounts
        public async Task<(int, string)> ListNetworkAccounts(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/accounts", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkBlocks
        public async Task<(int, string)> ListNetworkBlocks(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/blocks", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkBridges
        public async Task<(int, string)> ListNetworkBridges(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/bridges", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkConnectors
        public async Task<(int, string)> ListNetworkConnectors(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/connectors", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkContracts
        public async Task<(int, string)> ListNetworkContracts(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/contracts", networkID);
            return await this.Get(uri, args);
        }

        // GetNetworkContractDetails
        public async Task<(int, string)> GetNetworkContractDetails(string networkID, string contractID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/contracts/{1}", networkID, contractID);
            return await this.Get(uri, args);
        }

        // ListNetworkOracles
        public async Task<(int, string)> ListNetworkOracles(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/oracles", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkTokens
        public async Task<(int, string)> ListNetworkTokens(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/tokens", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkTransactions
        public async Task<(int, string)> ListNetworkTransactions(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/transactions", networkID);
            return await this.Get(uri, args);
        }

        // GetNetworkTransactionDetails
        public async Task<(int, string)> GetNetworkTransactionDetails(string networkID, string txID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/transactions/{1}", networkID, txID);
            return await this.Get(uri, args);
        }

        // GetNetworkStatusMeta
        public async Task<(int, string)> GetNetworkStatusMeta(string networkID, string txID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/status", networkID, txID);
            return await this.Get(uri, args);
        }

        // ListNetworkNodes
        public async Task<(int, string)> ListNetworkNodes(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes", networkID);
            return await this.Get(uri, args);
        }

        // CreateNetworkNode
        public async Task<(int, string)> CreateNetworkNode(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes", networkID);
            return await this.Post(uri, args);
        }

        // GetNetworkNodeDetails
        public async Task<(int, string)> GetNetworkNodeDetails(string networkID, string nodeID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes/{1}", networkID, nodeID);
            return await this.Get(uri, args);
        }

        // GetNetworkNodeLogs
        public async Task<(int, string)> GetNetworkNodeLogs(string networkID, string nodeID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes/{1}/logs", networkID, nodeID);
            return await this.Get(uri, args);
        }

        // DeleteNetworkNode
        public async Task<(int, string)> DeleteNetworkNode(string networkID, string nodeID) {
            var uri = String.Format("networks/{0}/nodes/{1}", networkID, nodeID);
            return await this.Delete(uri);
        }

        // CreateOracle
        public async Task<(int, string)> CreateOracle(Dictionary<string, object> args) {
            return await this.Post("oracles", args);
        }

        // ListOracles
        public async Task<(int, string)> ListOracles(Dictionary<string, object> args) {
            return await this.Get("oracles", args);
        }

        // GetOracleDetails
        public async Task<(int, string)> GetOracleDetails(string oracleID, Dictionary<string, object> args) {
            var uri = String.Format("oracles/{0}", oracleID);
            return await this.Get(uri, args);
        }

        // CreateTokenContract
        public async Task<(int, string)> CreateTokenContract(Dictionary<string, object> args) {
            return await this.Post("tokens", args);
        }

        // ListTokenContracts
        public async Task<(int, string)> ListTokenContracts(Dictionary<string, object> args) {
            return await this.Get("tokens", args);
        }

        // GetTokenContractDetails
        public async Task<(int, string)> GetTokenContractDetails(string tokenID, Dictionary<string, object> args) {
            var uri = String.Format("tokens/{0}", tokenID);
            return await this.Get(uri, args);
        }

        // CreateTransaction
        public async Task<(int, string)> CreateTransaction(Dictionary<string, object> args) {
            return await this.Post("transactions", args);
        }

        // ListTransactions
        public async Task<(int, string)> ListTransactions(Dictionary<string, object> args) {
            return await this.Get("transactions", args);
        }

        // GetTransactionDetails
        public async Task<(int, string)> GetTransactionDetails(string txID, Dictionary<string, object> args) {
            var uri = String.Format("transactions/{0}", txID);
            return await this.Get(uri, args);
        }

        // CreateWallet
        public async Task<(int, string)> CreateWallet(Dictionary<string, object> args) {
            return await this.Post("wallets", args);
        }

        // ListWallets
        public async Task<(int, string)> ListWallets(Dictionary<string, object> args) {
            return await this.Get("wallets", args);
        }

        // ListWalletAccounts
        public async Task<(int, string)> ListWalletAccounts(string walletID, Dictionary<string, object> args) {
            var uri = String.Format("wallets/{0}/accounts", walletID);
            return await this.Get(uri, args);
        }

        // GetWalletDetails
        public async Task<(int, string)> GetWalletDetails(string walletID, Dictionary<string, object> args) {
            var uri = String.Format("wallets/{0}", walletID);
            return await this.Get(uri, args);
        }
    }
}
