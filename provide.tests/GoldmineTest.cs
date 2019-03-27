using System;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace provide.tests
{
    public class GoldmineTest
    {
        [Fact]
        public void TestGoldmineTxCreateWithIPFSHash()
        {
            var ipfsTask = IPFSClient.Add("some encrypted document");
            var hashAwaiter = ipfsTask.GetAwaiter();
            ipfsTask.Wait();
            var hash = hashAwaiter.GetResult();

            var apiToken = "provide application api token";
            var contractID = "provide contract id";
            var tx = provide.Goldmine.ExecuteContract(apiToken, contractID, new Dictionary<string, object> {
                { "wallet_id", "provide wallet id" },
                { "method", "send" },
                { "params", new string[] { "test", "test", "test", "test", "test", "test", hash } },
                { "value", 0 }
            });
            var awaiter = tx.GetAwaiter();
            tx.Wait();
            Console.WriteLine(awaiter.GetResult().Item2);
        }
    }
}
