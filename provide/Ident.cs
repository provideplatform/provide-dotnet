using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace provide
{
    public class Ident: ApiClient
    {

        public Ident(string token) : base("ident.provide.services", "api/v1", "https", token) {}

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

        // // CreateApplication on behalf of the given API token
        // func CreateApplication(string token, Dictionary<string, object> params) (int, interface{}, error) {
        //     return InitIdent(token).Post("applications", params)
        // }

        // // UpdateApplication using the given API token, application id and params
        // func UpdateApplication(token, applicationID string, Dictionary<string, object> params) (int, interface{}, error) {
        //     uri := fmt.Sprintf("applications/%s", applicationID)
        //     return InitIdent(token).Put(uri, params)
        // }

        // // ListApplications retrieves a paginated list of applications scoped to the given API token
        // func ListApplications(string token, Dictionary<string, object> params) (int, interface{}, error) {
        //     return InitIdent(token).Get("applications", params)
        // }

        // // GetApplicationDetails retrives application details for the given API token and application id
        // func GetApplicationDetails(token, applicationID string, Dictionary<string, object> params) (int, interface{}, error) {
        //     uri := fmt.Sprintf("applications/%s", applicationID)
        //     return InitIdent(token).Get(uri, params)
        // }

        // // ListApplicationTokens retrieves a paginated list of application API tokens
        // func ListApplicationTokens(token, applicationID string, Dictionary<string, object> params) (int, interface{}, error) {
        //     uri := fmt.Sprintf("applications/%s/tokens", applicationID)
        //     return InitIdent(token).Get(uri, params)
        // }

        // // CreateApplicationToken creates a new API token for the given application ID.
        // func CreateApplicationToken(token, applicationID string, Dictionary<string, object> params) (int, interface{}, error) {
        //     params["application_id"] = applicationID
        //     return InitIdent(token).Post("tokens", params)
        // }

        // // CreateToken creates a new API token.
        // func CreateToken(string token, Dictionary<string, object> params) (int, interface{}, error) {
        //     return InitIdent(token).Post("tokens", params)
        // }

        // // ListTokens retrieves a paginated list of API tokens scoped to the given API token
        // func ListTokens(string token, Dictionary<string, object> params) (int, interface{}, error) {
        //     return InitIdent(token).Get("tokens", params)
        // }

        // // GetTokenDetails retrieves details for the given API token id
        // func GetTokenDetails(token, tokenID string, Dictionary<string, object> params) (int, interface{}, error) {
        //     uri := fmt.Sprintf("tokens/%s", tokenID)
        //     return InitIdent(token).Get(uri, params)
        // }

        // // DeleteToken removes a previously authorized API token, effectively deauthorizing future calls using the token
        // func DeleteToken(token, tokenID string) (int, interface{}, error) {
        //     uri := fmt.Sprintf("tokens/%s", tokenID)
        //     return InitIdent(token).Delete(uri)
        // }

        // // CreateUser creates a new user for which API tokens and managed signing identities can be authorized
        // func CreateUser(string token, Dictionary<string, object> params) (int, interface{}, error) {
        //     return InitIdent(token).Post("users", params)
        // }

        // // ListUsers retrieves a paginated list of users scoped to the given API token
        // func ListUsers(string token, Dictionary<string, object> params) (int, interface{}, error) {
        //     return InitIdent(token).Get("users", params)
        // }

        // // GetUserDetails retrieves details for the given user id
        // func GetUserDetails(token, userID string, Dictionary<string, object> params) (int, interface{}, error) {
        //     uri := fmt.Sprintf("users/%s", userID)
        //     return InitIdent(token).Get(uri, params)
        // }

        // // UpdateUser updates an existing user
        // func UpdateUser(token, userID string, Dictionary<string, object> params) (int, interface{}, error) {
        //     uri := fmt.Sprintf("users/%s", userID)
        //     return InitIdent(token).Put(uri, params)
        // }
    }
}
