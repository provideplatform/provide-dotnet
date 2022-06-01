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

namespace provide.Baseline.Model
{
    public class ProtocolMessage
    {
        public string OpCode { get; set; } // up to 40 bits
        public string Sender { get; set; } // up to 336 bits
        public string Recipient { get; set; } // up to 336 bits
        public string Shield { get; set; } // up to 336 bits
        public string Identifier { get; set; } // up to 288 bits (i.e., UUIDv4 circuit/workflow identifier)
        public string Signature { get; set; } // 512 bits
        public string Type { get; set; }  // 1 bit
        public byte[] Payload { get; set; } // arbitrary length
    }
}