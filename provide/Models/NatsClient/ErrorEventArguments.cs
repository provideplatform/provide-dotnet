namespace provide.Models.NatsClient
{
    public class ErrorEventArguments
    {
        public string Error { get; set; }
        public string ConnectedUrl { get; set; }
        public string Subject { get; set; }

        public static ErrorEventArguments FromNatsEntity(NATS.Client.ErrEventArgs args)
        {
            return new ErrorEventArguments()
            {
                ConnectedUrl = args.Conn.ConnectedUrl,
                Error = args.Error,
                Subject = args.Subscription.Subject
            };
        }
    }
}
