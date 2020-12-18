using System;

namespace provide.Models.NatsClient
{
    public class ConnectionEventArguments
    {
        public string ConnectedUrl { get; set; }
        public Exception Error { get; set; }

        public static ConnectionEventArguments FromNatsEntity(NATS.Client.ConnEventArgs args)
        {
            return new ConnectionEventArguments()
            {
                ConnectedUrl = args.Conn.ConnectedUrl,
                Error = args.Error
            };
        }
    }
}
