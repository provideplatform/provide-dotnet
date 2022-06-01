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

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using provide.Model.Privacy;

namespace provide
{
    public class Privacy : ApiClient
    {
        const string DEFAULT_HOST = "privacy.provide.services";
        const string DEFAULT_PATH = "api/v1";
        const string DEFAULT_SCHEME = "https";
        const string HOST_ENVIRONMENT_VAR = "PRIVACY_API_HOST";
        const string SCHEME_ENVIRONMENT_VAR = "PRIVACY_API_SCHEME";
        const string PATH_ENVIRONMENT_VAR = "PRIVACY_API_PATH";

        public Privacy(string token) : base(token) { }
        public Privacy(string host, string path, string scheme, string token) : base(host, path, scheme, token) { }

        public static Privacy InitPrivacy(string token)
        {
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

            return new Privacy(host, path, scheme, token);
        }

        // ListCircuits fetches a list of provisioned circuits
        public async Task<provide.Model.Privacy.Circuit[]> ListCircuits(Dictionary<string, object> args)
        {
            return await this.Get<provide.Model.Privacy.Circuit[]>("circuits", args);
        }

        // GetCircuitDetails returns details about the given circuit
        public async Task<List<provide.Model.Privacy.Circuit>> GetCircuitDetails(string circuitId, Dictionary<string, object> args)
        {
            var uri = $"circuits/{circuitId}";
            return await this.Get<List<provide.Model.Privacy.Circuit>>(uri, args);
        }

        // DeployCircuit provisions a new circuit
        public async Task<provide.Model.Privacy.Circuit> DeployCircuit(Circuit circuit)
        {
            return await this.Post<provide.Model.Privacy.Circuit>("circuits", circuit);
        }

        // Prove generates a proof for the given circuit
        public async Task<provide.Model.Privacy.ProveResponse> Prove(string circuitId, ProveRequest req)
        {
            var uri = $"circuits/{circuitId}/prove";
            return await this.Post<provide.Model.Privacy.ProveResponse>(uri, req);
        }

        // Verify a proof for the given circuit
        public async Task<provide.Model.Privacy.VerifyResponse> Verify(string circuitId, VerifyRequest req)
        {
            var uri = $"circuits/{circuitId}/verify";
            return await this.Post<provide.Model.Privacy.VerifyResponse>(uri, req);
        }
    }
}
