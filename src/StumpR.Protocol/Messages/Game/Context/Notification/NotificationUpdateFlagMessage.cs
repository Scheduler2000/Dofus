using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NotificationUpdateFlagMessage : Message
{
    public const uint Id = 8604;

    public NotificationUpdateFlagMessage(ushort index)
    {
        Index = index;
    }

    public NotificationUpdateFlagMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort Index { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(Index);
    }

    public override void Deserialize(IDataReader reader)
    {
        Index = reader.ReadVarUShort();
    }
}