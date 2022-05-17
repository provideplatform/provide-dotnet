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
            client.Subscribe(TestSubject, (sender, args) => { });
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
            var expectedPayload = new byte[3] { 1, 2, 3 };
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
            client.Subscribe(TestSubject, (sender, args) => { });

            client.Close();
            Assert.Equal(ConnState.CLOSED, client.GetConnectionState());
            Assert.Equal(0, client.GetSubscriptionCount());
        }

        [Fact]
        public void TestConnectionEvents()
        {
            var onDisconnectedResetEvent = new AutoResetEvent(false);
            var onClosedResetEvent = new AutoResetEvent(false);

            var onDisconnectedCalled = false;
            var onClosedCalled = false;

            var client = SetupNatsClient();

            client.OnDisconnected += (object sender, Models.NatsClient.ConnectionEventArguments args) =>
            {
                onDisconnectedCalled = true;
                onDisconnectedResetEvent.Set();
            };

            client.OnClosed += (object sender, Models.NatsClient.ConnectionEventArguments args) =>
            {
                onClosedCalled = true;
                onClosedResetEvent.Set();
            };

            client.Connect();
            client.Close();

            onDisconnectedResetEvent.WaitOne();
            onClosedResetEvent.WaitOne();

            Assert.True(onDisconnectedCalled);
            Assert.True(onClosedCalled);
        }
    }
}
