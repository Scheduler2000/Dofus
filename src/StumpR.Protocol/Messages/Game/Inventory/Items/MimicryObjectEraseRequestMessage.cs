using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MimicryObjectEraseRequestMessage : Message
{
    public const uint Id = 3575;

    public MimicryObjectEraseRequestMessage(uint hostUID, byte hostPos)
    {
        HostUID = hostUID;
        HostPos = hostPos;
    }

    public MimicryObjectEraseRequestMessage()
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