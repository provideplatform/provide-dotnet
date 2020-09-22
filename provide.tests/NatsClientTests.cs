using System;
using System.Threading.Tasks;
using NATS.Client;
using Xunit;

namespace provide.tests
{
    public class NatsClientTests
    {
        private async Task<NatsClient> SetupNatsClient()
        {
            var token = await IdentTestUtil.CreateIdentForTestUser();
            return new NatsClient(token);
        }

        [Fact]
        public async void TestConnection()
        {
            var client = await SetupNatsClient();
            client.Connect();

            Assert.Equal(ConnState.CONNECTED, client.GetConnectionState());
        }

        [Fact]
        public async void TestSubscribeAndUnsubscribe() 
        {
            var client = await SetupNatsClient();
            client.Connect();

            Assert.Equal(0, client.GetSubscriptionCount());
            client.Subscribe("network.*.status", (sender, args) => {});
            Assert.Equal(1, client.GetSubscriptionCount());
            client.Unsubscribe("network.*.status");
            Assert.Equal(0, client.GetSubscriptionCount());
        }

        [Fact]
        public async void TestConnectionClose()
        {
            var client = await SetupNatsClient();
            client.Connect();

            client.Close();
            Assert.Equal(ConnState.CLOSED, client.GetConnectionState());
        }
    }

}
