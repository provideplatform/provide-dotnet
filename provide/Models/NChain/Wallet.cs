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

using Newtonsoft.Json;
using System;

namespace provide.Model.NChain
{
    public class Wallet: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? WalletId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UserId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Address  { get; set; }

        public string Path  { get; set; }

        public int? Purpose  { get; set; }

        public string Mnemonic  { get; set; }

        public string Seed  { get; set; }

        public string PublicKey  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PrivateKey  { get; set; }
    }
}
