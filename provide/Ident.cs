using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace provide
{
    public class Ident: ApiClient
    {

        public Ident(string token) : base(token) {}

        public static Ident InitIdent(string token) {
            return new Ident(token);
        }

        // Authenticate a user by email address and password, returning a newly-authorized API token
        public static async Task<(int, object)> Authenticate(string email, string passwd) {
            return await InitIdent(null).Post("authenticate", new Dictionary<string, object> {
                { "email", email },
                { "password", passwd }
            });
        }

        // CreateApplication on behalf of the given API token
        public static async Task<(int, object)>CreateApplication(string token, Dictionary<string, object> args) {
            return await InitIdent(token).Post("applications", args);
        }

        // UpdateApplication using the given API token, application id and args
        public static async Task<(int, object)>UpdateApplication(string token, string applicationID, Dictionary<string, object> args) {
            var uri = String.Format("applications/{0}", applicationID);
            return await InitIdent(token).Put(uri, args);
        }

        // ListApplications retrieves a paginated list of applications scoped to the given API token
        public static async Task<(int, object)>ListApplications(string token, Dictionary<string, object> args) {
            return await InitIdent(token).Get("applications", args);
        }

        // GetApplicationDetails retrives application details for the given API token and application id
        public static async Task<(int, object)>GetApplicationDetails(string token, string applicationID, Dictionary<string, object> args) {
            var uri = String.Format("applications/{0}", applicationID);
            return await InitIdent(token).Get(uri, args);
        }

        // ListApplicationTokens retrieves a paginated list of application API tokens
        public static async Task<(int, object)>ListApplicationTokens(string token, string applicationID, Dictionary<string, object> args) {
            var uri = String.Format("applications/{0}/tokens", applicationID);
            return await InitIdent(token).Get(uri, args);
        }

        // CreateApplicationToken creates a new API token for the given application ID.
        public static async Task<(int, object)>CreateApplicationToken(string token, string applicationID, Dictionary<string, object> args) {
            args["application_id"] = applicationID;
            return await InitIdent(token).Post("tokens", args);
        }

        // CreateToken creates a new API token.
        public static async Task<(int, object)>CreateToken(string token, Dictionary<string, object> args) {
            return await InitIdent(token).Post("tokens", args);
        }

        // ListTokens retrieves a paginated list of API tokens scoped to the given API token
        public static async Task<(int, object)>ListTokens(string token, Dictionary<string, object> args) {
            return await InitIdent(token).Get("tokens", args);
        }

        // GetTokenDetails retrieves details for the given API token id
        public static async Task<(int, object)>GetTokenDetails(string token, string tokenID, Dictionary<string, object> args) {
            var uri = String.Format("tokens/{0}", tokenID);
            return await InitIdent(token).Get(uri, args);
        }

        // DeleteToken removes a previously authorized API token, effectively deauthorizing future calls using the token
        public static async Task<(int, object)>DeleteToken(string token, string tokenID) {
            var uri = String.Format("tokens/{0}", tokenID);
            return await InitIdent(token).Delete(uri);
        }

        // CreateUser creates a new user for which API tokens and managed signing identities can be authorized
        public static async Task<(int, object)>CreateUser(string token, Dictionary<string, object> args) {
            return await InitIdent(token).Post("users", args);
        }

        // ListUsers retrieves a paginated list of users scoped to the given API token
        public static async Task<(int, object)>ListUsers(string token, Dictionary<string, object> args) {
            return await InitIdent(token).Get("users", args);
        }

        // GetUserDetails retrieves details for the given user id
        public static async Task<(int, object)>GetUserDetails(string token, string userID, Dictionary<string, object> args) {
            var uri = String.Format("users/{0}", userID);
            return await InitIdent(token).Get(uri, args);
        }

        // UpdateUser updates an existing user
        public static async Task<(int, object)>UpdateUser(string token, string userID, Dictionary<string, object> args) {
            var uri = String.Format("users/{0}", userID);
            return await InitIdent(token).Put(uri, args);
        }
    }
}
