using System;
using System.Collections.Generic;
using Xunit;

namespace provide.tests
{
    public class GoldmineTest
    {
        [Fact]
        public void TestGoldmineTxCreateWithIPFSHash()
        {
            var ipfsTask = IPFSClient.Add(String.Format("some encrypted document @ {0}", DateTime.Now));
            var hashAwaiter = ipfsTask.GetAwaiter();
            ipfsTask.Wait();
            var hash = hashAwaiter.GetResult();
            Console.WriteLine(hash);

            var apiToken = "";
            var contractID = "";
            var tx = provide.Goldmine.ExecuteContract(apiToken, contractID, new Dictionary<string, object> {
                { "wallet_id", "" },
                { "method", "send" },
                { "params", new string[] { "test", "test", "test", "test", "test", "test", hash } },
                { "value", 0 }
            });
            var awaiter = tx.GetAwaiter();
            tx.Wait();

            var ipfsGetTask = IPFSClient.Get(hash);
            var docAwaiter = ipfsGetTask.GetAwaiter();
            ipfsGetTask.Wait();
            var doc = docAwaiter.GetResult();
            Console.WriteLine(doc);
        }
    }
}
