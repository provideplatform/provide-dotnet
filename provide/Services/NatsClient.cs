using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NATS.Client;

namespace provide 
{
    public class NatsClient 
    {
        private string host;
        private string path;
        private string scheme;
        private string token;
        private readonly string natsUrl;

        private IConnection connection;

        private Dictionary<string, IAsyncSubscription> subscriptions = new Dictionary<string, IAsyncSubscription>();

        public NatsClient()
        {
            this.natsUrl = "nats://localhost:4222";
        }

        public NatsClient(string host, string path, string scheme, string token)
        {
            this.host = host;
            this.path = path;
            this.scheme = scheme;
            this.token = token;
            this.natsUrl =  $"{scheme}://${host}/${path}/";
        }

        public void Connect() 
        {
            // are default options good enough?
            var opts = ConnectionFactory.GetDefaultOptions();
            opts.Token = this.token;
            opts.Url = this.natsUrl;
            this.connection = new ConnectionFactory().CreateConnection(opts);
        }

        public void Close()
        {
            if (this.connection.IsClosed()) 
            {
                return;
            }
            // should we do drain instead?
            this.connection.Close();
        }

        public void Publish(string subject, string reply, byte[] payload)
        {
            this.connection.Publish(subject, reply, payload);
        }

        public IAsyncSubscription Subscribe(string subject, EventHandler<MsgHandlerEventArgs> msgHandler)
        {
            var subscription = this.connection.SubscribeAsync(subject, msgHandler);
            this.subscriptions.Add(subject, subscription);
            return subscription;
        }

        // it looks like this is the only way to unsubcribe from specific subscription
        // this method might be redundant but keeping it just to have all functionalities
        public void Unsubscribe(IAsyncSubscription subscription)
        {
            subscription.Unsubscribe();
        }

        // might not be needed
        public void Unsubscribe(string subject)
        {
            IAsyncSubscription subscription;
            if (this.subscriptions.TryGetValue(subject, out subscription) && subscription != null)
            {
                subscription.Unsubscribe();
            }
            else 
            {
                throw new NATSBadSubscriptionException("Can not find subscription to unsubscribe");
            }
        }

        public async Task<Msg> RequestAsync(string subject, int timeout, byte[] payload)
        {
            return await this.connection.RequestAsync(subject, payload, timeout);
        }

        // not sure if needed, just for testing purpose
        private void WireUpGenericHandler(Options opts) 
        {
            opts.ClosedEventHandler += OnCloseEvent;
            opts.DisconnectedEventHandler += OnDisconnectEvent;
            opts.ReconnectedEventHandler += OnReconnectedEvent;
        }

        private void OnReconnectedEvent(object sender, ConnEventArgs e)
        {
            Console.WriteLine("reconnect event", sender, e);
        }

        private void OnDisconnectEvent(object sender, ConnEventArgs e)
        {
            Console.WriteLine("disconnect event", sender, e);
        }

        private void OnCloseEvent(object sender, ConnEventArgs e)
        {
            Console.WriteLine("close event", sender, e);
        }
    }    
}
