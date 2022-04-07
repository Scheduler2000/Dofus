using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BasicAckMessage : Message
{
    public const uint Id = 45;

    public BasicAckMessage(uint seq, ushort lastPacketId)
    {
        Seq = seq;
        LastPacketId = lastPacketId;
    }

    public BasicAckMessage()
    {
    }

    public override uint MessageId => Id;

    public uint Seq { get; set; }

    public ushort LastPacketId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(Seq);
        writer.WriteVarUShort(LastPacketId);
    }

    public override void Deserialize(IDataReader reader)
    {
        Seq = reader.ReadVarUInt();
        LastPacketId = reader.ReadVarUShort();
    }
}