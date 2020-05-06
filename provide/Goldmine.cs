using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace provide
{
    public class Goldmine: ApiClient
    {
        public Goldmine(string token) : base(token) {}

        public Goldmine InitGoldmine(string token) {
            return new Goldmine(token);
        }

        // CreateAccount
        public async Task<(int, byte[])> CreateAccount(Dictionary<string, object> args) {
            return await this.Post("accounts", args);
        }

        // ListAccounts
        public async Task<(int, byte[])> ListAccounts(Dictionary<string, object> args) {
            return await this.Get("accounts", args);
        }

        // GetAccountDetails
        public async Task<(int, byte[])> GetAccountDetails(string accountID, Dictionary<string, object> args) {
            var uri = String.Format("accounts/{0}", accountID);
            return await this.Get(uri, args);
        }

        // GetAccountBalance
        public async Task<(int, byte[])> GetAccountBalance(string accountID, string tokenID, Dictionary<string, object> args) {
            var uri = String.Format("accounts/{0}/balances/{1}", accountID, tokenID);
            return await this.Get(uri, args);
        }

        // CreateBridge
        public async Task<(int, byte[])> CreateBridge(Dictionary<string, object> args) {
            return await this.Post("bridges", args);
        }

        // ListBridges
        public async Task<(int, byte[])> ListBridges(Dictionary<string, object> args) {
            return await this.Get("bridges", args);
        }

        // GetBridgeDetails
        public async Task<(int, byte[])> GetBridgeDetails(string bridgeID, Dictionary<string, object> args) {
            var uri = String.Format("bridges/{0}", bridgeID);
            return await this.Get(uri, args);
        }

        // CreateConnector
        public async Task<(int, byte[])> CreateConnector(Dictionary<string, object> args) {
            return await this.Post("connectors", args);
        }

        // ListConnectors
        public async Task<(int, byte[])> ListConnectors(Dictionary<string, object> args) {
            return await this.Get("connectors", args);
        }

        // GetConnectorDetails
        public async Task<(int, byte[])> GetConnectorDetails(string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}", connectorID);
            return await this.Get(uri, args);
        }

        // DeleteConnector
        public async Task<(int, byte[])> DeleteConnector(string connectorID) {
            var uri = String.Format("connectors/{0}", connectorID);
            return await this.Delete(uri);
        }

        // ListConnectedEntities -- invokes the configured connector proxy in a RESTful manner -- i.e., GET /
        public async Task<(int, byte[])> ListConnectedEntities(string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities", connectorID);
            return await this.Get(uri, args);
        }

        // GetConnectedEntityDetails -- invokes the configured connector proxy in a RESTful manner -- i.e., GET /:id
        public async Task<(int, byte[])> GetConnectedEntityDetails(string connectorID, string entityID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await this.Get(uri, args);
        }

        // CreateConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., POST /
        public async Task<(int, byte[])> CreateConnectedEntity(string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities", connectorID);
            return await this.Post(uri, args);
        }

        // UpdateConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., PUT /:id
        public async Task<(int, byte[])> UpdateConnectedEntity(string connectorID, string entityID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await this.Put(uri, args);
        }

        // DeleteConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., DELETE /:id
        public async Task<(int, byte[])> DeleteConnectedEntity(string connectorID, string entityID) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await this.Delete(uri);
        }

        // CreateContract
        public async Task<(int, byte[])> CreateContract(Dictionary<string, object> args) {
            return await this.Post("contracts", args);
        }

        // ExecuteContract
        public async Task<(int, byte[])> ExecuteContract(string contractID, Dictionary<string, object> args) {
            var uri = String.Format("contracts/{0}/execute", contractID);
            return await this.Post(uri, args);
        }

        // ListContracts
        public async Task<(int, byte[])> ListContracts(Dictionary<string, object> args) {
            return await this.Get("contracts", args);
        }

        // GetContractDetails
        public async Task<(int, byte[])> GetContractDetails(string contractID, Dictionary<string, object> args) {
            var uri = String.Format("contracts/{0}", contractID);
            return await this.Get(uri, args);
        }

        // CreateNetwork
        public async Task<(int, byte[])> CreateNetwork(Dictionary<string, object> args) {
            return await this.Post("networks", args);
        }

        // UpdateNetwork updates an existing network
        public async Task<(int, byte[])> UpdateNetwork(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}", networkID);
            return await this.Put(uri, args);
        }

        // ListNetworks
        public async Task<(int, byte[])> ListNetworks(Dictionary<string, object> args) {
            return await this.Get("networks", args);
        }

        // GetNetworkDetails
        public async Task<(int, byte[])> GetNetworkDetails(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkAccounts
        public async Task<(int, byte[])> ListNetworkAccounts(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/accounts", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkBlocks
        public async Task<(int, byte[])> ListNetworkBlocks(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/blocks", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkBridges
        public async Task<(int, byte[])> ListNetworkBridges(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/bridges", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkConnectors
        public async Task<(int, byte[])> ListNetworkConnectors(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/connectors", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkContracts
        public async Task<(int, byte[])> ListNetworkContracts(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/contracts", networkID);
            return await this.Get(uri, args);
        }

        // GetNetworkContractDetails
        public async Task<(int, byte[])> GetNetworkContractDetails(string networkID, string contractID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/contracts/{1}", networkID, contractID);
            return await this.Get(uri, args);
        }

        // ListNetworkOracles
        public async Task<(int, byte[])> ListNetworkOracles(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/oracles", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkTokens
        public async Task<(int, byte[])> ListNetworkTokens(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/tokens", networkID);
            return await this.Get(uri, args);
        }

        // ListNetworkTransactions
        public async Task<(int, byte[])> ListNetworkTransactions(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/transactions", networkID);
            return await this.Get(uri, args);
        }

        // GetNetworkTransactionDetails
        public async Task<(int, byte[])> GetNetworkTransactionDetails(string networkID, string txID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/transactions/{1}", networkID, txID);
            return await this.Get(uri, args);
        }

        // GetNetworkStatusMeta
        public async Task<(int, byte[])> GetNetworkStatusMeta(string networkID, string txID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/status", networkID, txID);
            return await this.Get(uri, args);
        }

        // ListNetworkNodes
        public async Task<(int, byte[])> ListNetworkNodes(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes", networkID);
            return await this.Get(uri, args);
        }

        // CreateNetworkNode
        public async Task<(int, byte[])> CreateNetworkNode(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes", networkID);
            return await this.Post(uri, args);
        }

        // GetNetworkNodeDetails
        public async Task<(int, byte[])> GetNetworkNodeDetails(string networkID, string nodeID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes/{1}", networkID, nodeID);
            return await this.Get(uri, args);
        }

        // GetNetworkNodeLogs
        public async Task<(int, byte[])> GetNetworkNodeLogs(string networkID, string nodeID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes/{1}/logs", networkID, nodeID);
            return await this.Get(uri, args);
        }

        // DeleteNetworkNode
        public async Task<(int, byte[])> DeleteNetworkNode(string networkID, string nodeID) {
            var uri = String.Format("networks/{0}/nodes/{1}", networkID, nodeID);
            return await this.Delete(uri);
        }

        // CreateOracle
        public async Task<(int, byte[])> CreateOracle(Dictionary<string, object> args) {
            return await this.Post("oracles", args);
        }

        // ListOracles
        public async Task<(int, byte[])> ListOracles(Dictionary<string, object> args) {
            return await this.Get("oracles", args);
        }

        // GetOracleDetails
        public async Task<(int, byte[])> GetOracleDetails(string oracleID, Dictionary<string, object> args) {
            var uri = String.Format("oracles/{0}", oracleID);
            return await this.Get(uri, args);
        }

        // CreateTokenContract
        public async Task<(int, byte[])> CreateTokenContract(Dictionary<string, object> args) {
            return await this.Post("tokens", args);
        }

        // ListTokenContracts
        public async Task<(int, byte[])> ListTokenContracts(Dictionary<string, object> args) {
            return await this.Get("tokens", args);
        }

        // GetTokenContractDetails
        public async Task<(int, byte[])> GetTokenContractDetails(string tokenID, Dictionary<string, object> args) {
            var uri = String.Format("tokens/{0}", tokenID);
            return await this.Get(uri, args);
        }

        // CreateTransaction
        public async Task<(int, byte[])> CreateTransaction(Dictionary<string, object> args) {
            return await this.Post("transactions", args);
        }

        // ListTransactions
        public async Task<(int, byte[])> ListTransactions(Dictionary<string, object> args) {
            return await this.Get("transactions", args);
        }

        // GetTransactionDetails
        public async Task<(int, byte[])> GetTransactionDetails(string txID, Dictionary<string, object> args) {
            var uri = String.Format("transactions/{0}", txID);
            return await this.Get(uri, args);
        }

        // CreateWallet
        public async Task<(int, byte[])> CreateWallet(Dictionary<string, object> args) {
            return await this.Post("wallets", args);
        }

        // ListWallets
        public async Task<(int, byte[])> ListWallets(Dictionary<string, object> args) {
            return await this.Get("wallets", args);
        }

        // ListWalletAccounts
        public async Task<(int, byte[])> ListWalletAccounts(string walletID, Dictionary<string, object> args) {
            var uri = String.Format("wallets/{0}/accounts", walletID);
            return await this.Get(uri, args);
        }

        // GetWalletDetails
        public async Task<(int, byte[])> GetWalletDetails(string walletID, Dictionary<string, object> args) {
            var uri = String.Format("wallets/{0}", walletID);
            return await this.Get(uri, args);
        }
    }
}
