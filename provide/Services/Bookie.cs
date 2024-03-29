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

using provide.Model.Client;
using provide.Model.Bookie;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace provide
{
    public class Bookie: ApiClient
    {
        const string DEFAULT_HOST = "bookie.provide.services";
        const string DEFAULT_PATH = "api/v1";
        const string DEFAULT_SCHEME = "https";
        const string HOST_ENVIRONMENT_VAR = "BOOKIE_API_HOST";
        const string SCHEME_ENVIRONMENT_VAR = "BOOKIE_API_SCHEME";
        const string PATH_ENVIRONMENT_VAR = "BOOKIE_API_PATH";

        public Bookie(string token) : base(token) {}
        public Bookie(string host, string path, string scheme, string token) : base(host, path, scheme, token) {}
    
        public static Bookie InitBookie(string token)
        {
            Bookie bookie;
            try {
                bookie = new Bookie(token);
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

                bookie = new Bookie(host, path, scheme, token);
            }

            return bookie;
        }

        // Broadcast a payment using api.providepayments.com
        public async Task<Payment> BroadcastTransaction(Payment payment)
        {
            return await this.Post<Payment>("payments", payment);
        }
    }
}
