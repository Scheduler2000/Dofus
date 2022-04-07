using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseKickRequestMessage : Message
{
    public const uint Id = 8499;

    public HouseKickRequestMessage(ulong objectId)
    {
        ObjectId = objectId;
    }

    public HouseKickRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong ObjectId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(ObjectId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarULong();
    }
}