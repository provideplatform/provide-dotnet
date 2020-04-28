using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace provide
{
    public class Vault: ApiClient
    {

        public Vault(string token) : base(token) {}

        public static Vault InitVault(string token) {
            return new Vault(token);
        }
        
        // CreateVault creates a new vault available within the key management service
        public static async Task<(int, object)>CreateVault(string token, Dictionary<string, object> args) {
            var uri = String.Format("vaults");
            return await InitVault(token).Post(uri, args);
        }

        // ListVaults lists available vaults available within the key management service
        public static async Task<(int, object)>ListVaults(string token, Dictionary<string, object> args) {
            var uri = String.Format("vaults");
            return await InitVault(token).Get(uri, args);
        }

        // ListVaultKeys retrieves a list of the symmetric keys and asymmetric key pairs secured within the key management service
        public static async Task<(int, object)>ListVaultKeys(string token, string vaultID, Dictionary<string, object> args) {
            var uri = String.Format("vaults/{}", vaultID);
            return await InitVault(token).Get(uri, args);
        }

        // CreateVault creates a new vault available within the key management service
        public static async Task<(int, object)>CreateVaultKey(string token, string vaultID, Dictionary<string, object> args) {
            var uri = String.Format("vaults/{}/keys", vaultID);
            return await InitVault(token).Post(uri, args);
        }

        // DeleteVaultKey permanently removes the specified key material from within the key management service
        public static async Task<(int, object)>DeleteVaultKey(string token, string vaultID) {
            var uri = String.Format("vaults/{}/keys", vaultID);
            return await InitVault(token).Delete(uri);
        }

        // SignMessage securely signs the given message
        public static async Task<(int, object)>SignMessage(string token, string vaultID, string keyID, string msg) {
            var uri = String.Format("vaults/{}/keys/{}/sign", vaultID, keyID);
            return await InitVault(token).Post(uri, new Dictionary<string, object> { { "message", msg } });
        }

        // VerifySignature verifies that a message was previously signed with a given key
        public static async Task<(int, object)>VerifySignature(string token, string vaultID, string keyID, string msg) {
            var uri = String.Format("vaults/{}/keys/{}/verify", vaultID, keyID);
            return await InitVault(token).Post(uri, new Dictionary<string, object> { { "message", msg } });
        }
    }
}
