using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace provide
{
    public class Goldmine: ApiClient
    {
        public Goldmine(string token) : base("goldmine.provide.services", "api/v1", "https", token) {}

        public static Goldmine InitGoldmine(string token) {
            return new Goldmine(token);
        }

        // CreateAccount
        public static async Task<(int, object)> CreateAccount(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Post("accounts", args);
        }

        // ListAccounts
        public static async Task<(int, object)> ListAccounts(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Get("accounts", args);
        }

        // GetAccountDetails
        public static async Task<(int, object)> GetAccountDetails(string token, string accountID, Dictionary<string, object> args) {
            var uri = String.Format("accounts/{0}", accountID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // GetAccountBalance
        public static async Task<(int, object)> GetAccountBalance(string token, string accountID, string tokenID, Dictionary<string, object> args) {
            var uri = String.Format("accounts/{0}/balances/{1}", accountID, tokenID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // CreateBridge
        public static async Task<(int, object)> CreateBridge(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Post("bridges", args);
        }

        // ListBridges
        public static async Task<(int, object)> ListBridges(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Get("bridges", args);
        }

        // GetBridgeDetails
        public static async Task<(int, object)> GetBridgeDetails(string token, string bridgeID, Dictionary<string, object> args) {
            var uri = String.Format("bridges/{0}", bridgeID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // CreateConnector
        public static async Task<(int, object)> CreateConnector(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Post("connectors", args);
        }

        // ListConnectors
        public static async Task<(int, object)> ListConnectors(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Get("connectors", args);
        }

        // GetConnectorDetails
        public static async Task<(int, object)> GetConnectorDetails(string token, string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}", connectorID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // DeleteConnector
        public static async Task<(int, object)> DeleteConnector(string token, string connectorID) {
            var uri = String.Format("connectors/{0}", connectorID);
            return await InitGoldmine(token).Delete(uri);
        }

        // ListConnectedEntities -- invokes the configured connector proxy in a RESTful manner -- i.e., GET /
        public static async Task<(int, object)> ListConnectedEntities(string token, string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities", connectorID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // GetConnectedEntityDetails -- invokes the configured connector proxy in a RESTful manner -- i.e., GET /:id
        public static async Task<(int, object)> GetConnectedEntityDetails(string token, string connectorID, string entityID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // CreateConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., POST /
        public static async Task<(int, object)> CreateConnectedEntity(string token, string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities", connectorID);
            return await InitGoldmine(token).Post(uri, args);
        }

        // UpdateConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., PUT /:id
        public static async Task<(int, object)> UpdateConnectedEntity(string token, string connectorID, string entityID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await InitGoldmine(token).Put(uri, args);
        }

        // DeleteConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., DELETE /:id
        public static async Task<(int, object)> DeleteConnectedEntity(string token, string connectorID, string entityID) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await InitGoldmine(token).Delete(uri);
        }

        // CreateContract
        public static async Task<(int, object)> CreateContract(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Post("contracts", args);
        }

        // ExecuteContract
        public static async Task<(int, object)> ExecuteContract(string token, string contractID, Dictionary<string, object> args) {
            var uri = String.Format("contracts/{0}/execute", contractID);
            return await InitGoldmine(token).Post(uri, args);
        }

        // ListContracts
        public static async Task<(int, object)> ListContracts(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Get("contracts", args);
        }

        // GetContractDetails
        public static async Task<(int, object)> GetContractDetails(string token, string contractID, Dictionary<string, object> args) {
            var uri = String.Format("contracts/{0}", contractID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // CreateNetwork
        public static async Task<(int, object)> CreateNetwork(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Post("networks", args);
        }

        // UpdateNetwork updates an existing network
        public static async Task<(int, object)> UpdateNetwork(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}", networkID);
            return await InitGoldmine(token).Put(uri, args);
        }

        // ListNetworks
        public static async Task<(int, object)> ListNetworks(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Get("networks", args);
        }

        // GetNetworkDetails
        public static async Task<(int, object)> GetNetworkDetails(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}", networkID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // ListNetworkAccounts
        public static async Task<(int, object)> ListNetworkAccounts(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/accounts", networkID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // ListNetworkBlocks
        public static async Task<(int, object)> ListNetworkBlocks(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/blocks", networkID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // ListNetworkBridges
        public static async Task<(int, object)> ListNetworkBridges(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/bridges", networkID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // ListNetworkConnectors
        public static async Task<(int, object)> ListNetworkConnectors(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/connectors", networkID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // ListNetworkContracts
        public static async Task<(int, object)> ListNetworkContracts(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/contracts", networkID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // GetNetworkContractDetails
        public static async Task<(int, object)> GetNetworkContractDetails(string token, string networkID, string contractID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/contracts/{1}", networkID, contractID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // ListNetworkOracles
        public static async Task<(int, object)> ListNetworkOracles(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/oracles", networkID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // ListNetworkTokens
        public static async Task<(int, object)> ListNetworkTokens(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/tokens", networkID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // ListNetworkTransactions
        public static async Task<(int, object)> ListNetworkTransactions(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/transactions", networkID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // GetNetworkTransactionDetails
        public static async Task<(int, object)> GetNetworkTransactionDetails(string token, string networkID, string txID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/transactions/{1}", networkID, txID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // GetNetworkStatusMeta
        public static async Task<(int, object)> GetNetworkStatusMeta(string token, string networkID, string txID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/status", networkID, txID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // ListNetworkNodes
        public static async Task<(int, object)> ListNetworkNodes(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes", networkID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // CreateNetworkNode
        public static async Task<(int, object)> CreateNetworkNode(string token, string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes", networkID);
            return await InitGoldmine(token).Post(uri, args);
        }

        // GetNetworkNodeDetails
        public static async Task<(int, object)> GetNetworkNodeDetails(string token, string networkID, string nodeID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes/{1}", networkID, nodeID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // GetNetworkNodeLogs
        public static async Task<(int, object)> GetNetworkNodeLogs(string token, string networkID, string nodeID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes/{1}/logs", networkID, nodeID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // DeleteNetworkNode
        public static async Task<(int, object)> DeleteNetworkNode(string token, string networkID, string nodeID) {
            var uri = String.Format("networks/{0}/nodes/{1}", networkID, nodeID);
            return await InitGoldmine(token).Delete(uri);
        }

        // CreateOracle
        public static async Task<(int, object)> CreateOracle(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Post("oracles", args);
        }

        // ListOracles
        public static async Task<(int, object)> ListOracles(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Get("oracles", args);
        }

        // GetOracleDetails
        public static async Task<(int, object)> GetOracleDetails(string token, string oracleID, Dictionary<string, object> args) {
            var uri = String.Format("oracles/{0}", oracleID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // CreateTokenContract
        public static async Task<(int, object)> CreateTokenContract(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Post("tokens", args);
        }

        // ListTokenContracts
        public static async Task<(int, object)> ListTokenContracts(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Get("tokens", args);
        }

        // GetTokenContractDetails
        public static async Task<(int, object)> GetTokenContractDetails(string token, string tokenID, Dictionary<string, object> args) {
            var uri = String.Format("tokens/{0}", tokenID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // CreateTransaction
        public static async Task<(int, object)> CreateTransaction(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Post("transactions", args);
        }

        // ListTransactions
        public static async Task<(int, object)> ListTransactions(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Get("transactions", args);
        }

        // GetTransactionDetails
        public static async Task<(int, object)> GetTransactionDetails(string token, string txID, Dictionary<string, object> args) {
            var uri = String.Format("transactions/{0}", txID);
            return await InitGoldmine(token).Get(uri, args);
        }

        // CreateWallet
        public static async Task<(int, object)> CreateWallet(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Post("wallets", args);
        }

        // ListWallets
        public static async Task<(int, object)> ListWallets(string token, Dictionary<string, object> args) {
            return await InitGoldmine(token).Get("wallets", args);
        }

        // GetWalletDetails
        public static async Task<(int, object)> GetWalletDetails(string token, string walletID, Dictionary<string, object> args) {
            var uri = String.Format("wallets/{0}", walletID);
            return await InitGoldmine(token).Get(uri, args);
        }
    }
}
