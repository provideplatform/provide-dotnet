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
    public class Workflow
    {
        /// <summary>
        /// Reference to the underlying circuit.
        /// </summary>
        public Circuit Circuit  { get; set; }

        /// <summary>
        /// Commitments[0] is latest commitment (new commitments are prepended to array).
        /// </summary>
        public Commitment[] Commitments { get; set; }

        /// <summary>
        /// Subset of parties in a workgroup.
        /// </summary>
        public Participant[] Participants { get; set; }

        /// <summary>
        /// Workflow identifier (should match circuit.id).
        /// </summary>
        public string Identifier  { get; set; }

        /// <summary>
        /// Shield contract address.
        /// </summary>
        public string Shield  { get; set; }

        /// <summary>
        /// Map of model name to model representing the underlying domain model and its local persistent store (i.e. system of record).
        /// </summary>
        public Dictionary<string, Model> Persistence { get; set; }

        /// <summary>
        /// Arbitrary workflow metadata.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }
    }
}
