using System;
using System.Threading.Tasks;

using Ipfs.Http;

namespace provide
{
    public class IPFSClient: IpfsClient
    {
        public static IPFSClient DefaultIPFSClient() {
            return new IPFSClient("https://ipfs.provide.services:5001");
        }

        public IPFSClient(string url) : base(url) {}

        public async Task<string> Add(string data) {
            var resp = await FileSystem.AddTextAsync(data);
            return (string) resp.Id;
        }

        public async Task<string> Get(string hash) {
            return await FileSystem.ReadAllTextAsync(hash);
        }
    }
}
