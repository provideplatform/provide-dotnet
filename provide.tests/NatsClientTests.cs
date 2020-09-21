using NATS.Client;
using Xunit;

namespace provide.tests
{
    public class NatsClientTests
    {
        [Fact]
        public async void TestConnection()
        {
            var token = await IdentTestUtil.CreateIdentForTestUser();
            var client = new NatsClient(token);
            client.Connect();

            Assert.Equal(ConnState.CONNECTED, client.GetConnectionState());
        }
    }

}
