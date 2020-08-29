using provide.Model.Client;
using provide.Model.Ident;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace provide
{
    public class Ident: ApiClient
    {
        const string DEFAULT_HOST = "ident.provide.services";
        const string DEFAULT_PATH = "api/v1";
        const string DEFAULT_SCHEME = "https";
        const string HOST_ENVIRONMENT_VAR = "IDENT_API_HOST";
        const string SCHEME_ENVIRONMENT_VAR = "IDENT_API_SCHEME";
        const string PATH_ENVIRONMENT_VAR = "IDENT_API_PATH";

        public Ident(string token) : base(token) {}
        public Ident(string host, string path, string scheme, string token) : base(host, path, scheme, token) {}
    
        public static Ident InitIdent(string token)
        {
            Ident ident;
            try {
                ident = new Ident(token);
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

                ident = new Ident(host, path, scheme, token);
            }

            return ident;
        }

        // Authenticate a user by email address and password, returning a newly-authorized API token
        public static async Task<AuthResponse> Authenticate(Auth auth)
        {
            return await InitIdent(null).Post2<AuthResponse>("authenticate", auth);
        }

        // CreateApplication on behalf of the given API token
        public async Task<ApplicationResponse>CreateApplication(Application application)
        {
            return await this.Post2<ApplicationResponse>("applications", application);
        }

        // UpdateApplication using the given API token, application id and args
        public async Task<(int, string)>UpdateApplication(string applicationID, Dictionary<string, object> args)
        {
            var uri = String.Format("applications/{0}", applicationID);
            return await this.Put(uri, args);
        }

        // ListApplications retrieves a paginated list of applications scoped to the given API token
        public async Task<List<Application>>ListApplications(Application application)
        {
            return await this.Get2<List<Application>>("applications", application);
        }

        // GetApplicationDetails retrives application details for the given API token and application id
        public async Task<Application>GetApplicationDetails(Guid applicationID, Application application)
        {
            var uri = String.Format("applications/{0}", applicationID);
            return await this.Get2<Application>(uri, application);
        }

        // ListApplicationTokens retrieves a paginated list of application API tokens
        public async Task<(int, string)>ListApplicationTokens(string applicationID, Dictionary<string, object> args)
        {
            var uri = String.Format("applications/{0}/tokens", applicationID);
            return await this.Get(uri, args);
        }

        // CreateApplicationToken creates a new API token for the given application ID.
        public async Task<(int, string)>CreateApplicationToken(string applicationID, Dictionary<string, object> args)
        {
            args["application_id"] = applicationID;
            return await this.Post("tokens", args);
        }

        // CreateOrganization on behalf of the given user
        public async Task<Organization>CreateOrganization(Organization organization)
        {
            return await this.Post2<Organization>("organizations", organization);
        }

        // UpdateOrganization using the given API token, organization id and args
        public async Task<(int, string)>UpdateOrganization(string organizationID, Dictionary<string, object> args)
        {
            var uri = String.Format("organizations/{0}", organizationID);
            return await this.Put(uri, args);
        }

        // ListOrganizations retrieves a paginated list of organizations scoped to the given API token
        public async Task<(int, string)>ListOrganizations(Dictionary<string, object> args)
        {
            return await this.Get("organizations", args);
        }

        // GetOrganizationDetails retrives organization details for the given API token and organization id
        public async Task<(int, string)>GetOrganizationDetails(string organizationID, Dictionary<string, object> args)
        {
            var uri = String.Format("organizations/{0}", organizationID);
            return await this.Get(uri, args);
        }

        // CreateToken creates a new API token.
        public async Task<(int, string)>CreateToken(Dictionary<string, object> args)
        {
            return await this.Post("tokens", args);
        }

        // ListTokens retrieves a paginated list of API tokens scoped to the given API token
        public async Task<(int, string)>ListTokens(Dictionary<string, object> args)
        {
            return await this.Get("tokens", args);
        }

        // GetTokenDetails retrieves details for the given API token id
        public async Task<(int, string)>GetTokenDetails(string tokenID, Dictionary<string, object> args)
        {
            var uri = String.Format("tokens/{0}", tokenID);
            return await this.Get(uri, args);
        }

        // DeleteToken removes a previously authorized API token, effectively deauthorizing future calls using the token
        public async Task<(int, string)>DeleteToken(string tokenID)
        {
            var uri = String.Format("tokens/{0}", tokenID);
            return await this.Delete(uri);
        }

        // CreateUser creates a new user for which API tokens and managed signing identities can be authorized
        public async Task<User>CreateUser(User user)
        {
            return await this.Post2<User>("users", user);
        }

        // ListUsers retrieves a paginated list of users scoped to the given API token
        public async Task<(int, string)>ListUsers(Dictionary<string, object> args)
        {
            return await this.Get("users", args);
        }

        // GetUserDetails retrieves details for the given user id
        public async Task<(int, string)>GetUserDetails(string userID, Dictionary<string, object> args)
        {
            var uri = String.Format("users/{0}", userID);
            return await this.Get(uri, args);
        }

        // UpdateUser updates an existing user
        public async Task<(int, string)>UpdateUser(string userID, Dictionary<string, object> args)
        {
            var uri = String.Format("users/{0}", userID);
            return await this.Put(uri, args);
        }
    }
}
