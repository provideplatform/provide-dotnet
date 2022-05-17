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
    public class Store
    {
        /// <summary>
        /// Optional system of record identifier (i.e. document name, UUID or primary key of relational record).
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Arbitrary metadata.
        /// </summary>
        public Dictionary<string, object> Metadata { get; set; }

        /// <summary>
        /// The system of record persistence provider. 
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// Url referencing the local system of record (i.e. DSN in the case of relational SQL database).
        /// </summary>
        public string Url { get; set; }
    }
}
