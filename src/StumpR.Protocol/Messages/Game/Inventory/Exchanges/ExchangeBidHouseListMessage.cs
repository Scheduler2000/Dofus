using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHouseListMessage : Message
{
    public const uint Id = 2675;

    public ExchangeBidHouseListMessage(ushort objectId, bool follow)
    {
        ObjectId = objectId;
        Follow = follow;
    }

    public ExchangeBidHouseListMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ObjectId { get; set; }

    public bool Follow { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObjectId);
        writer.WriteBoolean(Follow);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUShort();
        Follow = reader.ReadBoolean();
    }
}