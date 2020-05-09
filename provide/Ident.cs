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
        public static async Task<(int, byte[])> Authenticate(string email, string passwd) {
            return await InitIdent(null).Post("authenticate", new Dictionary<string, object> {
                { "email", email },
                { "password", passwd }
            });
        }

        // CreateApplication on behalf of the given API token
        public async Task<(int, byte[])>CreateApplication(Dictionary<string, object> args) {
            return await this.Post("applications", args);
        }

        // UpdateApplication using the given API token, application id and args
        public async Task<(int, byte[])>UpdateApplication(string applicationID, Dictionary<string, object> args) {
            var uri = String.Format("applications/{0}", applicationID);
            return await this.Put(uri, args);
        }

        // ListApplications retrieves a paginated list of applications scoped to the given API token
        public async Task<(int, byte[])>ListApplications(Dictionary<string, object> args) {
            return await this.Get("applications", args);
        }

        // GetApplicationDetails retrives application details for the given API token and application id
        public async Task<(int, byte[])>GetApplicationDetails(string applicationID, Dictionary<string, object> args) {
            var uri = String.Format("applications/{0}", applicationID);
            return await this.Get(uri, args);
        }

        // ListApplicationTokens retrieves a paginated list of application API tokens
        public async Task<(int, byte[])>ListApplicationTokens(string applicationID, Dictionary<string, object> args) {
            var uri = String.Format("applications/{0}/tokens", applicationID);
            return await this.Get(uri, args);
        }

        // CreateApplicationToken creates a new API token for the given application ID.
        public async Task<(int, byte[])>CreateApplicationToken(string applicationID, Dictionary<string, object> args) {
            args["application_id"] = applicationID;
            return await this.Post("tokens", args);
        }

        // CreateOrganization on behalf of the given user
        public async Task<(int, byte[])>CreateOrganization(Dictionary<string, object> args) {
            return await this.Post("organizations", args);
        }

        // UpdateOrganization using the given API token, organization id and args
        public async Task<(int, byte[])>UpdateOrganization(string organizationID, Dictionary<string, object> args) {
            var uri = String.Format("organizations/{0}", organizationID);
            return await this.Put(uri, args);
        }

        // ListOrganizations retrieves a paginated list of organizations scoped to the given API token
        public async Task<(int, byte[])>ListOrganizations(Dictionary<string, object> args) {
            return await this.Get("organizations", args);
        }

        // GetOrganizationDetails retrives organization details for the given API token and organization id
        public async Task<(int, byte[])>GetOrganizationDetails(string organizationID, Dictionary<string, object> args) {
            var uri = String.Format("organizations/{0}", organizationID);
            return await this.Get(uri, args);
        }

        // CreateToken creates a new API token.
        public async Task<(int, byte[])>CreateToken(Dictionary<string, object> args) {
            return await this.Post("tokens", args);
        }

        // ListTokens retrieves a paginated list of API tokens scoped to the given API token
        public async Task<(int, byte[])>ListTokens(Dictionary<string, object> args) {
            return await this.Get("tokens", args);
        }

        // GetTokenDetails retrieves details for the given API token id
        public async Task<(int, byte[])>GetTokenDetails(string tokenID, Dictionary<string, object> args) {
            var uri = String.Format("tokens/{0}", tokenID);
            return await this.Get(uri, args);
        }

        // DeleteToken removes a previously authorized API token, effectively deauthorizing future calls using the token
        public async Task<(int, byte[])>DeleteToken(string tokenID) {
            var uri = String.Format("tokens/{0}", tokenID);
            return await this.Delete(uri);
        }

        // CreateUser creates a new user for which API tokens and managed signing identities can be authorized
        public async Task<(int, byte[])>CreateUser(Dictionary<string, object> args) {
            return await this.Post("users", args);
        }

        // ListUsers retrieves a paginated list of users scoped to the given API token
        public async Task<(int, byte[])>ListUsers(Dictionary<string, object> args) {
            return await this.Get("users", args);
        }

        // GetUserDetails retrieves details for the given user id
        public async Task<(int, byte[])>GetUserDetails(string userID, Dictionary<string, object> args) {
            var uri = String.Format("users/{0}", userID);
            return await this.Get(uri, args);
        }

        // UpdateUser updates an existing user
        public async Task<(int, byte[])>UpdateUser(string userID, Dictionary<string, object> args) {
            var uri = String.Format("users/{0}", userID);
            return await this.Put(uri, args);
        }
    }
}
