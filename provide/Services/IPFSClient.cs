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

using Ipfs.Http;
using System.Threading.Tasks;

namespace provide
{
    public class IPFSClient: IpfsClient
    {
        public static IPFSClient DefaultIPFSClient() {
            return new IPFSClient("http://ipfs.provide.services:5001");
        }

        public IPFSClient(string url) : base(url) {}

        public static async Task<string> Add(string data) {
            var resp = await DefaultIPFSClient().FileSystem.AddTextAsync(data);
            return (string) resp.Id;
        }

        public static async Task<string> Get(string hash) {
            return await DefaultIPFSClient().FileSystem.ReadAllTextAsync(hash);
        }
    }
}
