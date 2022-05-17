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

using System.Collections.Generic;

namespace provide.Baseline.Model
{
    public class Commitment
    {
        /// <summary>
        /// Arbitrary data. 
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// Abstract location of the commitment (i.e., in the case of a merkle tree, this is the leaf index)
        /// </summary>
        public long Location { get; set; }

        /// <summary>
        /// Salt such that currentHash = H(data + salt). 
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Array of proofs;
        /// </summary>
        public long[] Proof { get; set; }

        /// <summary>
        /// Public inputs used to generate the commitment
        /// </summary>
        public string[] PublicInputs { get; set; }

        /// <summary>
        /// Address of participant who created the commitment. 
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Allows mapping from participant address -> signature. 
        /// </summary>
        public Dictionary<string, string> Signatures { get; set; }

        /// <summary>
        /// Unix timestamp when the commitment was pushed. 
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// Commitment value. 
        /// </summary>
        public string Value { get; set; }
    }
}
