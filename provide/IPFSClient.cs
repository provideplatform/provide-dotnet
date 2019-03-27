using System;
using System.Threading.Tasks;

using Ipfs.Http;

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
