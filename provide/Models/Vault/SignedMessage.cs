namespace provide.Model.Vault
{
    // FIXME: type name probably can be better
    public class SignedMessage: BaseModel
    {
        public string Message { get; set; }

        public string Signature { get; set; }
    }
}
