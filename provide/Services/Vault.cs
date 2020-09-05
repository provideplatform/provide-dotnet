using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using provide.Model.Vault;

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

            return new Vault(host, path, scheme, token);
        }

        // CreateVault creates a new vault available within the key management service
        public async Task<provide.Model.Vault.Vault>CreateVault(provide.Model.Vault.Vault vault) {
            var uri = "vaults";
            return await this.Post<provide.Model.Vault.Vault>(uri, vault);
        }

        // ListVaults lists available vaults available within the key management service
        public async Task<List<provide.Model.Vault.Vault>>ListVaults(Dictionary<string, object> args) {
            var uri = "vaults";
            return await this.Get<List<provide.Model.Vault.Vault>>(uri, args);
        }

        // DeleteVault permanently removes specified vault from the key management service
        public async Task<provide.Model.Vault.Vault>DeleteVault(string vaultID) {
            var uri = $"vaults/{vaultID}";
            return await this.Delete<provide.Model.Vault.Vault>(uri);
        }

        // ListVaultKeys retrieves a list of the symmetric keys and asymmetric key pairs secured within the vault key management service
        public async Task<List<provide.Model.Vault.Key>>ListVaultKeys(string vaultID, Dictionary<string, object> args) {
            var uri = $"vaults/{vaultID}/keys";
            return await this.Get<List<provide.Model.Vault.Key>>(uri, args);
        }

        // CreateVaultKey creates a new key available within the vault key management service
        public async Task<provide.Model.Vault.Key>CreateVaultKey(string vaultID, provide.Model.Vault.Key key) {
            var uri = $"vaults/{vaultID}/keys";
            return await this.Post<provide.Model.Vault.Key>(uri, key);
        }

        // DeleteVaultKey permanently removes the specified key material from within the vault key management service
        public async Task<provide.Model.Vault.Key>DeleteVaultKey(string vaultID, string keyID) {
            var uri = $"vaults/{vaultID}/keys/{keyID}";
            return await this.Delete<provide.Model.Vault.Key>(uri);
        }

        // ListVaultSecrets retrieves a list of the secrets secured within the vault
        public async Task<List<provide.Model.Vault.Secret>>ListVaultSecrets(string vaultID, Dictionary<string, object> args) {
            var uri = $"vaults/{vaultID}/secrets";
            return await this.Get<List<provide.Model.Vault.Secret>>(uri, args);
        }

        // CreateVaultSecret creates a new secret within the vault
        public async Task<provide.Model.Vault.Secret>CreateVaultSecret(string vaultID, provide.Model.Vault.Secret secret) {
            var uri = $"vaults/{vaultID}/secrets";
            return await this.Post<provide.Model.Vault.Secret>(uri, secret);
        }

        // DeleteVaultSecret permanently removes the specified secret from the vault
        public async Task<provide.Model.Vault.Secret>DeleteVaultSecret(string vaultID, string secretID) {
            var uri = $"vaults/{vaultID}/secrets/{secretID}";
            return await this.Delete<provide.Model.Vault.Secret>(uri);
        }

        // SignMessage securely signs the given message
        public async Task<SignMessageResponse>SignMessage(string vaultID, string keyID, string msg) {
            var uri = $"vaults/{vaultID}/keys/{keyID}/sign";
            return await this.Post<SignMessageResponse>(uri, new SignMessageRequest { Message = msg });
        }

        // VerifySignature verifies that a message was previously signed with a given key
        public async Task<SignatureVerificationResponse>VerifySignature(string vaultID, string keyID, string msg, string sig) {
            var uri = $"vaults/{vaultID}/keys/{keyID}/verify";
            return await this.Post<SignatureVerificationResponse>(uri, new SignatureVerificationRequest { Message = msg, Signature = sig });
        }
    }
}
