// Copyright 2017-2022 Provide Technologies Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using provide.Model.Client;
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
            return await InitIdent(null).Post<AuthResponse>("authenticate", auth);
        }

        // Create a user
        public static async Task<User> CreateUser(User user)
        {
            return await InitIdent(null).Post<User>("users", user);
        }

        // CreateApplication on behalf of the given API token
        public async Task<Application>CreateApplication(Application application)
        {
            return await this.Post<Application>("applications", application);
        }

        // UpdateApplication using the given API token, application id and args
        public async Task<Application>UpdateApplication(string applicationID, Application application)
        {
            var uri = String.Format("applications/{0}", applicationID);
            return await this.Put<Application>(uri, application);
        }

        // ListApplications retrieves a paginated list of applications scoped to the given API token
        public async Task<List<Application>>ListApplications(Dictionary<string, object> query)
        {
            return await this.Get<List<Application>>("applications", query);
        }

        // GetApplicationDetails retrives application details for the given API token and application id
        public async Task<Application>GetApplicationDetails(Guid? applicationID, Dictionary<string, object> query)
        {
            var uri = String.Format("applications/{0}", applicationID);
            return await this.Get<Application>(uri, query);
        }

        // FetchApplicationOrganizations retrives application organizations for the given application id
        public async Task<List<Organization>>FetchApplicationOrganizations(string applicationID, Dictionary<string, object> query)
        {
            var uri = String.Format("applications/{0}/organizations", applicationID);
            return await this.Get<List<Organization>>(uri, query);
        }

        // AddApplicationOrganizations adds new organization to application given application id
        public async Task<Organization>AddApplicationOrganizations(string applicationID, ApplicationOrganization appOrg)
        {
            var uri = String.Format("applications/{0}/organizations", applicationID);
            return await this.Post<Organization>(uri, appOrg);
        }

        // ListApplicationTokens retrieves a paginated list of application API tokens
        public async Task<List<JWTToken>>ListApplicationTokens(string applicationID, Dictionary<string, object> args)
        {
            var uri = String.Format("applications/{0}/tokens", applicationID);
            return await this.Get<List<JWTToken>>(uri, args);
        }

        // CreateApplicationToken creates a new API token for the given application ID.
        public async Task<JWTToken>CreateApplicationToken(string applicationID, JWTToken token)
        {
            token.ApplicationId = Guid.Parse(applicationID);
            return await this.Post<JWTToken>("tokens", token);
        }

        // CreateOrganization on behalf of the given user
        public async Task<Organization>CreateOrganization(Organization organization)
        {
            return await this.Post<Organization>("organizations", organization);
        }

        // UpdateOrganization using the given API token, organization id and args
        public async Task<Organization>UpdateOrganization(string organizationID, Organization organization)
        {
            var uri = String.Format("organizations/{0}", organizationID);
            return await this.Put<Organization>(uri, organization);
        }

        // ListOrganizations retrieves a paginated list of organizations scoped to the given API token
        public async Task<List<Organization>>ListOrganizations(Dictionary<string, object> args)
        {
            return await this.Get<List<Organization>>("organizations", args);
        }

        // GetOrganizationDetails retrives organization details for the given API token and organization id
        public async Task<Organization>GetOrganizationDetails(string organizationID, Dictionary<string, object> args)
        {
            var uri = String.Format("organizations/{0}", organizationID);
            return await this.Get<Organization>(uri, args);
        }

        // CreateToken creates a new API token.
        public async Task<JWTToken>CreateToken(JWTToken token)
        {
            return await this.Post<JWTToken>("tokens", token);
        }

        // ListTokens retrieves a paginated list of API tokens scoped to the given API token
        public async Task<List<JWTToken>>ListTokens(Dictionary<string, object> args)
        {
            return await this.Get<List<JWTToken>>("tokens", args);
        }

        // GetTokenDetails retrieves details for the given API token id
        public async Task<JWTToken>GetTokenDetails(string tokenID, Dictionary<string, object> args)
        {
            var uri = String.Format("tokens/{0}", tokenID);
            return await this.Get<JWTToken>(uri, args);
        }

        // DeleteToken removes a previously authorized API token, effectively deauthorizing future calls using the token
        public async Task<JWTToken>DeleteToken(string tokenID)
        {
            var uri = String.Format("tokens/{0}", tokenID);
            return await this.Delete<JWTToken>(uri);
        }

        // ListUsers retrieves a paginated list of users scoped to the given API token
        public async Task<List<User>>ListUsers(Dictionary<string, object> args)
        {
            return await this.Get<List<User>>("users", args);
        }

        // GetUserDetails retrieves details for the given user id
        public async Task<User>GetUserDetails(string userID, Dictionary<string, object> args)
        {
            var uri = String.Format("users/{0}", userID);
            return await this.Get<User>(uri, args);
        }

        // UpdateUser updates an existing user
        public async Task<User>UpdateUser(string userID, User user)
        {
            var uri = String.Format("users/{0}", userID);
            return await this.Put<User>(uri, user);
        }
    }
}
