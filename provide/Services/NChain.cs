using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using provide.Model.Ident;
using provide.Model.NChain;

namespace provide
{
    public class NChain: ApiClient
    {
        const string DEFAULT_HOST = "nchain.provide.services";
        const string DEFAULT_PATH = "api/v1";
        const string DEFAULT_SCHEME = "https";
        const string HOST_ENVIRONMENT_VAR = "NCHAIN_API_HOST";
        const string SCHEME_ENVIRONMENT_VAR = "NCHAIN_API_SCHEME";
        const string PATH_ENVIRONMENT_VAR = "NCHAIN_API_PATH";

        public NChain(string token) : base(token) {}
        public NChain(string host, string path, string scheme, string token) : base(host, path, scheme, token) {}
    
        public static NChain InitNChain(string token)
        {
            NChain nchain;
            try {
                nchain = new NChain(token);
            } catch {
                string host = Environment.GetEnvironmentVariable(HOST_ENVIRONMENT_VAR);
                string path = Environment.GetEnvironmentVariable(PATH_ENVIRONMENT_VAR);
                string scheme = Environment.GetEnvironmentVariable(SCHEME_ENVIRONMENT_VAR);

                if (host == null)
                {
                    host = DEFAULT_HOST;
                }

                if (path == null)
                {
                    path = DEFAULT_PATH;
                }

                if (scheme == null)
                {
                    scheme = DEFAULT_SCHEME;
                }

                nchain = new NChain(host, path, scheme, token);
            }

            return nchain;
        }

        // CreateAccount
        public async Task<Account> CreateAccount(Account account) {
            return await this.Post<Account>("accounts", account);
        }

        // ListAccounts
        public async Task<List<Account>> ListAccounts(Dictionary<string, object> args) {
            return await this.Get<List<Account>>("accounts", args);
        }

        // GetAccountDetails
        public async Task<Account> GetAccountDetails(string accountID, Dictionary<string, object> args) {
            var uri = String.Format("accounts/{0}", accountID);
            return await this.Get<Account>(uri, args);
        }

        // GetAccountBalance
        // FIXME!!! this Account object may not return the balance properly...
        public async Task<Account> GetAccountBalance(string accountID, string tokenID, Dictionary<string, object> args) {
            var uri = String.Format("accounts/{0}/balances/{1}", accountID, tokenID);
            return await this.Get<Account>(uri, args);
        }

        // CreateBridge
        public async Task<Bridge> CreateBridge(Bridge bridge) {
            return await this.Post<Bridge>("bridges", bridge);
        }

        // ListBridges
        public async Task<List<Bridge>> ListBridges(Dictionary<string, object> args) {
            return await this.Get<List<Bridge>>("bridges", args);
        }

        // GetBridgeDetails
        public async Task<Bridge> GetBridgeDetails(string bridgeID, Dictionary<string, object> args) {
            var uri = String.Format("bridges/{0}", bridgeID);
            return await this.Get<Bridge>(uri, args);
        }

        // CreateConnector
        public async Task<Connector> CreateConnector(Connector connector) {
            // FIXME connector type
            return await this.Post<Connector>("connectors", connector);
        }

        // ListConnectors
        public async Task<List<Connector>> ListConnectors(Dictionary<string, object> args) {
            return await this.Get<List<Connector>>("connectors", args);
        }

        // GetConnectorDetails
        public async Task<Connector> GetConnectorDetails(string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}", connectorID);
            return await this.Get<Connector>(uri, args);
        }

        // DeleteConnector
        public async Task<Connector> DeleteConnector(string connectorID) {
            var uri = String.Format("connectors/{0}", connectorID);
            return await this.Delete<Connector>(uri);
        }

        // ListConnectedEntities -- invokes the configured connector proxy in a RESTful manner -- i.e., GET /
        public async Task<List<ConnectedEntity>> ListConnectedEntities(string connectorID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities", connectorID);
            return await this.Get<List<ConnectedEntity>>(uri, args);
        }

        // GetConnectedEntityDetails -- invokes the configured connector proxy in a RESTful manner -- i.e., GET /:id
        public async Task<ConnectedEntity> GetConnectedEntityDetails(string connectorID, string entityID, Dictionary<string, object> args) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await this.Get<ConnectedEntity>(uri, args);
        }

        // CreateConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., POST /
        public async Task<ConnectedEntity> CreateConnectedEntity(string connectorID, ConnectedEntity connectedEntity) {
            var uri = String.Format("connectors/{0}/entities", connectorID);
            return await this.Post<ConnectedEntity>(uri, connectedEntity);
        }

        // UpdateConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., PUT /:id
        public async Task<ConnectedEntity> UpdateConnectedEntity(string connectorID, string entityID, ConnectedEntity connectedEntity) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await this.Put<ConnectedEntity>(uri, connectedEntity);
        }

        // DeleteConnectedEntity -- invokes the configured connector proxy in a RESTful manner -- i.e., DELETE /:id
        public async Task<ConnectedEntity> DeleteConnectedEntity(string connectorID, string entityID) {
            var uri = String.Format("connectors/{0}/entities/{1}", connectorID, entityID);
            return await this.Delete<ConnectedEntity>(uri);
        }

        // CreateContract
        public async Task<Contract> CreateContract(Contract contract) {
            return await this.Post<Contract>("contracts", contract);
        }

        // ExecuteContract
        public async Task<ContractExecution> ExecuteContract(string contractID, Transaction tx) {
            var uri = String.Format("contracts/{0}/execute", contractID);
            return await this.Post<ContractExecution>(uri, tx);
        }

        // ListContracts
        public async Task<List<Contract>> ListContracts(Dictionary<string, object> args) {
            return await this.Get<List<Contract>>("contracts", args);
        }

        // GetContractDetails
        public async Task<Contract> GetContractDetails(string contractID, Dictionary<string, object> args) {
            var uri = String.Format("contracts/{0}", contractID);
            return await this.Get<Contract>(uri, args);
        }

        // CreateNetwork
        public async Task<Network> CreateNetwork(Network network) {
            return await this.Post<Network>("networks", network);
        }

        // UpdateNetwork updates an existing network
        public async Task<Network> UpdateNetwork(string networkID, Network network) {
            var uri = String.Format("networks/{0}", networkID);
            return await this.Put<Network>(uri, network);
        }

        // ListNetworks
        public async Task<List<Network>> ListNetworks(Dictionary<string, object> args) {
            return await this.Get<List<Network>>("networks", args);
        }

        // GetNetworkDetails
        public async Task<Network> GetNetworkDetails(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}", networkID);
            return await this.Get<Network>(uri, args);
        }

        // ListNetworkAccounts
        public async Task<List<Account>> ListNetworkAccounts(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/accounts", networkID);
            // FIXME is network account also account type?
            return await this.Get<List<Account>>(uri, args);
        }

        // ListNetworkBlocks
        // public async Task<(int, string)> ListNetworkBlocks(string networkID, Dictionary<string, object> args) {
        //     // FIXME block type
        //     var uri = String.Format("networks/{0}/blocks", networkID);
        //     return await this.Get(uri, args);
        // }

        // ListNetworkBridges
        public async Task<List<Bridge>> ListNetworkBridges(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/bridges", networkID);
            // FIXME is network bridge same bridge type?
            return await this.Get<List<Bridge>>(uri, args);
        }

        // ListNetworkConnectors
        public async Task<List<Connector>> ListNetworkConnectors(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/connectors", networkID);
            return await this.Get<List<Connector>>(uri, args);
        }

        // ListNetworkContracts
        public async Task<List<Contract>> ListNetworkContracts(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/contracts", networkID);
            // FIXME is network contract same contract type?
            return await this.Get<List<Contract>>(uri, args);
        }

        // GetNetworkContractDetails
        public async Task<Contract> GetNetworkContractDetails(string networkID, string contractID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/contracts/{1}", networkID, contractID);
            return await this.Get<Contract>(uri, args);
        }

        // ListNetworkOracles
        public async Task<List<Oracle>> ListNetworkOracles(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/oracles", networkID);
            return await this.Get<List<Oracle>>(uri, args);
        }

        // ListNetworkTokens
        public async Task<JWTToken> ListNetworkTokens(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/tokens", networkID);
            return await this.Get<JWTToken>(uri, args);
        }

        // ListNetworkTransactions
        public async Task<List<Transaction>> ListNetworkTransactions(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/transactions", networkID);
            return await this.Get<List<Transaction>>(uri, args);
        }

        // GetNetworkTransactionDetails
        public async Task<Transaction> GetNetworkTransactionDetails(string networkID, string txID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/transactions/{1}", networkID, txID);
            return await this.Get<Transaction>(uri, args);
        }

        // GetNetworkStatusMeta
        public async Task<NetworkStats> GetNetworkStatusMeta(string networkID, string txID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/status", networkID, txID);
            return await this.Get<NetworkStats>(uri, args);
        }

        // ListNetworkNodes
        public async Task<List<Node>> ListNetworkNodes(string networkID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes", networkID);
            return await this.Get<List<Node>>(uri, args);
        }

        // CreateNetworkNode
        public async Task<Node> CreateNetworkNode(string networkID, Node node) {
            var uri = String.Format("networks/{0}/nodes", networkID);
            return await this.Post<Node>(uri, node);
        }

        // GetNetworkNodeDetails
        public async Task<Node> GetNetworkNodeDetails(string networkID, string nodeID, Dictionary<string, object> args) {
            var uri = String.Format("networks/{0}/nodes/{1}", networkID, nodeID);
            return await this.Get<Node>(uri, args);
        }

        // GetNetworkNodeLogs
        public async Task<NodeLogs> GetNetworkNodeLogs(string networkID, string nodeID, Dictionary<string, object> args) {
            // FIXME network node type
            var uri = String.Format("networks/{0}/nodes/{1}/logs", networkID, nodeID);
            return await this.Get<NodeLogs>(uri, args);
        }

        // DeleteNetworkNode
        public async Task<Node> DeleteNetworkNode(string networkID, string nodeID) {
            var uri = String.Format("networks/{0}/nodes/{1}", networkID, nodeID);
            return await this.Delete<Node>(uri);
        }

        // CreateOracle
        public async Task<Oracle> CreateOracle(Oracle oracle) {
            return await this.Post<Oracle>("oracles", oracle);
        }

        // ListOracles
        public async Task<List<Oracle>> ListOracles(Dictionary<string, object> args) {
            return await this.Get<List<Oracle>>("oracles", args);
        }

        // GetOracleDetails
        public async Task<Oracle> GetOracleDetails(string oracleID, Dictionary<string, object> args) {
            var uri = String.Format("oracles/{0}", oracleID);
            return await this.Get<Oracle>(uri, args);
        }

        // CreateTokenContract
        public async Task<TokenContract> CreateTokenContract(TokenContract tokenContract) {
            return await this.Post<TokenContract>("tokens", tokenContract);
        }

        // ListTokenContracts
        public async Task<List<TokenContract>> ListTokenContracts(Dictionary<string, object> args) {
            return await this.Get<List<TokenContract>>("tokens", args);
        }

        // GetTokenContractDetails
        public async Task<TokenContract> GetTokenContractDetails(string tokenID, Dictionary<string, object> args) {
            var uri = String.Format("tokens/{0}", tokenID);
            return await this.Get<TokenContract>(uri, args);
        }

        // CreateTransaction
        public async Task<Transaction> CreateTransaction(Transaction transaction) {
            return await this.Post<Transaction>("transactions", transaction);
        }

        // ListTransactions
        public async Task<List<Transaction>> ListTransactions(Dictionary<string, object> args) {
            return await this.Get<List<Transaction>>("transactions", args);
        }

        // GetTransactionDetails
        public async Task<Transaction> GetTransactionDetails(string txID, Dictionary<string, object> args) {
            var uri = String.Format("transactions/{0}", txID);
            return await this.Get<Transaction>(uri, args);
        }

        // CreateWallet
        public async Task<Wallet> CreateWallet(Wallet wallet) {
            return await this.Post<Wallet>("wallets", wallet);
        }

        // ListWallets
        public async Task<List<Wallet>> ListWallets(Dictionary<string, object> args) {
            return await this.Get<List<Wallet>>("wallets", args);
        }

        // ListWalletAccounts
        public async Task<List<Account>> ListWalletAccounts(string walletID, Dictionary<string, object> args) {
            var uri = String.Format("wallets/{0}/accounts", walletID);
            return await this.Get<List<Account>>(uri, args);
        }

        // GetWalletDetails
        public async Task<Wallet> GetWalletDetails(string walletID, Dictionary<string, object> args) {
            var uri = String.Format("wallets/{0}", walletID);
            return await this.Get<Wallet>(uri, args);
        }
    }
}
