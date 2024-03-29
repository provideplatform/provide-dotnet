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

using Xunit;
using provide.Baseline.Model;
using provide.Baseline.Services;

public class MessageProtocolParserTests
{
    [Fact]
    public void MarshalingAndUnmarhalingMessage()
    {
        var sender = "0x96f1027fee06a15f42e48180705a2ecb2f846985";
        var recipient = "0x512aA2447D05fe172cF59C1200FBa0EF7D271231";
        var shield = "0x31B26EfC2B84ba8fE62b4f7A7F3D74606BAfD6D0";
        var identifier = "123e4567-e89b-12d3-a456-426655440000";
        var signature = "2f04ca19aa525862b827c55feec2f9a3743aaf6fa75f2d140733922cb05665f2";
        var payload = new byte[3] { 1, 2, 3 };
        var msg = new ProtocolMessage
        {
            OpCode = Constants.BLINE_OPCODE,
            Type = Constants.TEXT_PAYLOAD_TYPE,
            Sender = sender,
            Recipient = recipient,
            Shield = shield,
            Identifier = identifier,
            Signature = signature,
            Payload = payload
        };

        var marshaled = MessageProtocolParser.MarshalProtocolMessage(msg);

        var unmarshaled = MessageProtocolParser.UnmarshalProtocolMessage(marshaled);

        // checking if marshaling and unmarshaling results in initial message
        Assert.Equal(Constants.BLINE_OPCODE, unmarshaled.OpCode);
        Assert.Equal(Constants.TEXT_PAYLOAD_TYPE, unmarshaled.Type);
        Assert.Equal(sender, unmarshaled.Sender);
        Assert.Equal(recipient, unmarshaled.Recipient);
        Assert.Equal(shield, unmarshaled.Shield);
        Assert.Equal(signature, unmarshaled.Signature);
        Assert.Equal(payload, unmarshaled.Payload);
    }
}
