namespace provide.Baseline.Model
{
    public class ProtocolMessage
    {
        public string OpCode { get; set; } // up to 40 bits
        public string Sender { get; set; } // up to 336 bits
        public string Recipient { get; set; } // up to 336 bits
        public string Shield { get; set; } // up to 336 bits
        public string Identifier { get; set; } // up to 288 bits (i.e., UUIDv4 circuit/workflow identifier)
        public string Signature { get; set; } // 512 bits
        public string Type { get; set; }  // 1 bit
        public byte[] Payload { get; set; } // arbitrary length
    }
}