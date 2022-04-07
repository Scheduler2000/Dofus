using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class WrapperObjectDissociateRequestMessage : Message
{
    public const uint Id = 9634;

    public WrapperObjectDissociateRequestMessage(uint hostUID, byte hostPos)
    {
        HostUID = hostUID;
        HostPos = hostPos;
    }

    public WrapperObjectDissociateRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint HostUID { get; set; }

    public byte HostPos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(HostUID);
        writer.WriteByte(HostPos);
    }

    public override void Deserialize(IDataReader reader)
    {
        HostUID = reader.ReadVarUInt();
        HostPos = reader.ReadByte();
    }
}