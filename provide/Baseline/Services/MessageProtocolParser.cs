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

using System.IO;
using System.Text;
using provide.Baseline.Model;

namespace provide.Baseline.Services
{


    public static class MessageProtocolParser
    {
        const int MessageReservedBitsLength = 512;
        public static byte[] MarshalProtocolMessage(ProtocolMessage msg)
        {
            var reservedBits = new byte[MessageReservedBitsLength / 8];
            var buffer = new byte[5 + 42 + 42 + 42 + 36 + 64 + 1 + reservedBits.Length + msg.Payload.Length];

            using (MemoryStream ms = new MemoryStream(buffer))
            {
                using (BinaryWriter bw = new BinaryWriter(ms, Encoding.UTF8))
                {
                    bw.Write(msg.OpCode.ToCharArray());

                    bw.Seek(5, SeekOrigin.Begin);
                    bw.Write(msg.Sender.ToCharArray());

                    bw.Seek(5 + 42, SeekOrigin.Begin);
                    bw.Write(msg.Recipient.ToCharArray());

                    bw.Seek(5 + 42 + 42, SeekOrigin.Begin);
                    bw.Write(msg.Shield.ToCharArray());

                    bw.Seek(5 + 42 + 42 + 42, SeekOrigin.Begin);
                    bw.Write(msg.Identifier.ToCharArray());

                    bw.Seek(5 + 42 + 42 + 42 + 36, SeekOrigin.Begin);
                    bw.Write(reservedBits);

                    bw.Seek(5 + 42 + 42 + 42 + 36 + reservedBits.Length, SeekOrigin.Begin);
                    bw.Write(msg.Signature.ToCharArray());

                    bw.Seek(5 + 42 + 42 + 42 + 36 + reservedBits.Length + 64, SeekOrigin.Begin);
                    bw.Write(msg.Type.ToCharArray());

                    bw.Seek(5 + 42 + 42 + 42 + 36 + reservedBits.Length + 64 + 1, SeekOrigin.Begin);
                    bw.Write(msg.Payload);
                }
            }

            return buffer;
        }

        public static ProtocolMessage UnmarshalProtocolMessage(byte[] msg)
        {
            var reservedSize = MessageReservedBitsLength / 8;

            using (var ms = new MemoryStream(msg))
            {
                using (var br = new BinaryReader(ms, Encoding.UTF8))
                {
                    var opCode = Encoding.UTF8.GetString(br.ReadBytes(5));
                    var sender = Encoding.UTF8.GetString(br.ReadBytes(42));
                    var recipient = Encoding.UTF8.GetString(br.ReadBytes(42));
                    var shield = Encoding.UTF8.GetString(br.ReadBytes(42));
                    var identifier = Encoding.UTF8.GetString(br.ReadBytes(36));
                    var reserved = br.ReadBytes(reservedSize);
                    var signature = Encoding.UTF8.GetString(br.ReadBytes(64));
                    var type = Encoding.UTF8.GetString(br.ReadBytes(1));
                    var payload = br.ReadBytes(msg.Length - (5 + 42 + 42 + 42 + 36 + 64 + 1 + reservedSize));

                    return new ProtocolMessage
                    {
                        OpCode = opCode,
                        Type = type,
                        Sender = sender,
                        Recipient = recipient,
                        Shield = shield,
                        Identifier = identifier,
                        Signature = signature,
                        Payload = payload
                    };
                }
            }
        }
    }
}
