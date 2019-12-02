//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:07.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using Renaissance.Binary;
using Renaissance.Binary.Definition;
using Renaissance.Protocol.types.version;

namespace Renaissance.Protocol.messages.connection
{
    public class IdentificationMessage : IDofusMessage
    {
        public const int NetworkId = 888;
        public int ProtocolId { get { return NetworkId; } }

        public WrappedBool Autoconnect { get; set; }

        public string Lang { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public short ServerId { get; set; }

        public string ServerIp { get; set; }

        public string HardwareId { get; set; }

        public void Deserialize(DofusReader reader)
        {
            byte flag = reader.Read<byte>();
            Autoconnect = reader.ReadFlag(flag, 0);
            Lang = reader.Read<string>();
            Username = reader.Read<string>();
            Password = reader.Read<string>();
            ServerId = reader.Read<short>();
            ServerIp = reader.Read<string>();
            HardwareId = reader.Read<string>();
        }

        public byte[] Serialize()
        { throw new System.NotImplementedException(); }
    }

}
