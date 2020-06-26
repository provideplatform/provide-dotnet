using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace provide
{
    public class Vault: ApiClient
    {

        const string DEFAULT_HOST = "vault.provide.services";
        const string DEFAULT_PATH = "api/v1";
        const string DEFAULT_SCHEME = "https";
        const string HOST_ENVIRONMENT_VAR = "VAULT_API_HOST";
        const string SCHEME_ENVIRONMENT_VAR = "VAULT_API_SCHEME";
        const string PATH_ENVIRONMENT_VAR = "VAULT_API_PATH";

        public Vault(string token) : base(token) {}
        public Vault(string host, string path, string scheme, string token) : base(host, path, scheme, token) {}
    
        public static Vault InitVault(string token) {
            Vault vault;
            try {
                vault = new Vault(token);
            } catch {
                string host = Environment.GetEnvironmentVariable(HOST_ENVIRONMENT_VAR);
                string path = Environment.GetEnvironmentVariable(PATH_ENVIRONMENT_VAR);
                string scheme = Environment.GetEnvironmentVariable(SCHEME_ENVIRONMENT_VAR);

                if (host == null) {
                    host = DEFAULT_HOST;
                }

                if (path == null) {
                    path = DEFAULT_PATH;
                }

                if (scheme == null) {
                    scheme = DEFAULT_SCHEME;
                }

                vault = new Vault(host, path, scheme, token);
            }

            return vault;
        }
        
        // CreateVault creates a new vault available within the key management service
        public async Task<(int, string)>CreateVault(string token, Dictionary<string, object> args) {
            var uri = "vaults";
            return await this.Post(uri, args);
        }

        // ListVaults lists available vaults available within the key management service
        public async Task<(int, string)>ListVaults(string token, Dictionary<string, object> args) {
            var uri = "vaults";
            return await this.Get(uri, args);
        }
        
        // DeleteVault permanently removes specified vault from the key management service
        public async Task<(int, string)>DeleteVault(string token, string vaultID) {
            var uri = $"vaults/{vaultID}";
            return await this.Delete(uri);
        }

        // ListVaultKeys retrieves a list of the symmetric keys and asymmetric key pairs secured within the vault key management service
        public async Task<(int, string)>ListVaultKeys(string token, string vaultID, Dictionary<string, object> args) {
            var uri = $"vaults/{vaultID}/keys";
            return await this.Get(uri, args);
        }

        // CreateVaultKey creates a new key available within the vault key management service
        public async Task<(int, string)>CreateVaultKey(string token, string vaultID, Dictionary<string, object> args) {
            var uri = $"vaults/{vaultID}/keys";
            return await this.Post(uri, args);
        }

        // DeleteVaultKey permanently removes the specified key material from within the vault key management service
        public async Task<(int, string)>DeleteVaultKey(string token, string vaultID, string keyID) {
            var uri = $"vaults/{vaultID}/keys/{keyID}";
            return await this.Delete(uri);
        }

        // ListVaultSecrets retrieves a list of the secrets secured within the vault
        public async Task<(int, string)>ListVaultSecrets(string token, string vaultID, Dictionary<string, object> args) {
            var uri = $"vaults/{vaultID}/secrets";
            return await this.Get(uri, args);
        }

        // CreateVaultSecret creates a new secret within the vault
        public async Task<(int, string)>CreateVaultSecret(string token, string vaultID, Dictionary<string, object> args) {
            var uri = $"vaults/{vaultID}/secrets";
            return await this.Post(uri, args);
        }

        // DeleteVaultSecret permanently removes the specified secret from the vault
        public async Task<(int, string)>DeleteVaultSecret(string token, string vaultID, string secretID) {
            var uri = $"vaults/{vaultID}/secrets/{secretID}";
            return await this.Delete(uri);
        }

        // SignMessage securely signs the given message
        public async Task<(int, string)>SignMessage(string token, string vaultID, string keyID, string msg) {
            var uri = $"vaults/{vaultID}/keys/{keyID}/sign";
            return await this.Post(uri, new Dictionary<string, object> { { "message", msg } });
        }

        // VerifySignature verifies that a message was previously signed with a given key
        public async Task<(int, string)>VerifySignature(string token, string vaultID, string keyID, string msg, string sig) {
            var uri = $"vaults/{vaultID}/keys/{keyID}/verify";
            return await this.Post(uri, new Dictionary<string, object> { { "message", msg }, { "signature", sig } });
        }
    }
}
