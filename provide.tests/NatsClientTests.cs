using System.Threading;
using NATS.Client;
using Xunit;

namespace provide.tests
{
    public class NatsClientTests
    {
        const string TestSubject = "my.pub.subject";
        private NatsClient SetupNatsClient()
        {
            var token = TestUtil.GetTempNatsToken();
            return new NatsClient(token);
        }

        [Fact]
        public void TestConnection()
        {
            var client = SetupNatsClient();
            client.Connect();

            Assert.Equal(ConnState.CONNECTED, client.GetConnectionState());
        }

        [Fact]
        public void TestSubscribeAndUnsubscribe() 
        {
            var client = SetupNatsClient();
            client.Connect();

            Assert.Equal(0, client.GetSubscriptionCount());
            client.Subscribe(TestSubject, (sender, args) => {});
            Assert.Equal(1, client.GetSubscriptionCount());
            client.Unsubscribe(TestSubject);
            Assert.Equal(0, client.GetSubscriptionCount());
        }

        [Fact]
        public void TestPublish()
        {
            var autoResetEvent = new AutoResetEvent(false);
            var client = SetupNatsClient();

            client.Connect();
            byte[] actualPayload = new byte[3];
            var expectedPayload = new byte[3] { 1, 2, 3};
            var actualSubject = "";
            client.Subscribe(TestSubject, (sender, args) =>
            {
                actualSubject = args.Message.Subject;
                actualPayload = args.Message.Data;
                autoResetEvent.Set();
            });
            client.Publish(TestSubject, expectedPayload);
            autoResetEvent.WaitOne();

            Assert.Equal(expectedPayload, actualPayload);
            Assert.Equal(TestSubject, actualSubject);
        }

        [Fact]
        public void TestConnectionClose()
        {
            var client = SetupNatsClient();
            client.Connect();
            client.Subscribe(TestSubject, (sender, args) => {});

            client.Close();
            Assert.Equal(ConnState.CLOSED, client.GetConnectionState());
            Assert.Equal(0, client.GetSubscriptionCount());
        }
    }

}
