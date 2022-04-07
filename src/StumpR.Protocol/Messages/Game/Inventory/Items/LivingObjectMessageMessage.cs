using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LivingObjectMessageMessage : Message
{
    public const uint Id = 2593;

    public LivingObjectMessageMessage(ushort msgId, int timeStamp, string owner, ushort objectGenericId)
    {
        MsgId = msgId;
        TimeStamp = timeStamp;
        Owner = owner;
        ObjectGenericId = objectGenericId;
    }

    public LivingObjectMessageMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort MsgId { get; set; }

    public int TimeStamp { get; set; }

    public string Owner { get; set; }

    public ushort ObjectGenericId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(MsgId);
        writer.WriteInt(TimeStamp);
        writer.WriteUTF(Owner);
        writer.WriteVarUShort(ObjectGenericId);
    }

    public override void Deserialize(IDataReader reader)
    {
        MsgId = reader.ReadVarUShort();
        TimeStamp = reader.ReadInt();
        Owner = reader.ReadUTF();
        ObjectGenericId = reader.ReadVarUShort();
    }
}