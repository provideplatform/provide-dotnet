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

        public NatsClient(string token)
        {
            this.token = token;
        }

        public NatsClient(string host, string path, string scheme, string token)
        {
            this.host = host;
            this.path = path;
            this.scheme = scheme;
            this.token = token;
            this.natsUrl = $"{scheme}://${host}/${path}/";
        }

        public void Connect()
        {
            var opts = ConnectionFactory.GetDefaultOptions();
            SetJWTHandler(opts);
            // if not provided it will use default local server url
            opts.Url = this.natsUrl;
            try
            {
                this.connection = new ConnectionFactory().CreateConnection(opts);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to establish nats connection: {ex}");
                throw ex;
            }
        }

        public ConnState GetConnectionState()
        {
            return this.connection.State;
        }

        public void Close()
        {
            if (this.connection.IsClosed()) 
            {
                return;
            }
            this.connection.Close();
        }

        public int GetSubscriptionCount() 
        {
            return this.connection.SubscriptionCount;
        }

        public void Publish(string subject, string reply, byte[] payload)
        {
            this.connection.Publish(subject, reply, payload);
        }

        public void Publish(string subject, byte[] payload)
        {
            this.connection.Publish(subject, payload);
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

        public void Unsubscribe(string subject)
        {
            IAsyncSubscription subscription;
            if (this.subscriptions.TryGetValue(subject, out subscription) && subscription != null)
            {
                subscription.Unsubscribe();
            }
            else 
            {
                throw new Exception("Can not find subscription to unsubscribe");
            }
        }

        public async Task<Msg> RequestAsync(string subject, int timeout, byte[] payload)
        {
            return await this.connection.RequestAsync(subject, payload, timeout);
        }
        
        private void SetJWTHandler(Options opts)
        {
            EventHandler<UserJWTEventArgs> jwtEh = (sender, args) =>
            {
                args.JWT = this.token;
            };

            EventHandler<UserSignatureEventArgs> sigEh = (sender, args) =>
            {
                // nats.net requires this to be set, setting it to empty so we don't get exception
                args.SignedNonce = new byte[64];
            };
            opts.SetJWTEventHandlers(jwtEh, sigEh);
        }
    }    
}
