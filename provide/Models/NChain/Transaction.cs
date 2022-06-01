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
using System.Collections.Generic;
using System.Numerics;

namespace provide.Model.NChain
{
    public class Transaction: BaseModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? NetworkId { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ApplicationId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? ContractId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? AccountId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? UserId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Guid? KeyId  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Signer  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string To  { get; set; }

        public BigInteger Value  { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Data { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Hash { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Ref { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        // check what traces is
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Traces { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Block { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BlockTimestamp { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BroadcastAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string FinalizedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string PublishedAt { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int PublishLatency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int BroadcastLatency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int E2eLatency { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] Params { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Method { get; set; }
    }
}
