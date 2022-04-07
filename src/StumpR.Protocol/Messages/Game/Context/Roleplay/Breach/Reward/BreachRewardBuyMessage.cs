using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachRewardBuyMessage : Message
{
    public const uint Id = 2995;

    public BreachRewardBuyMessage(uint objectId)
    {
        ObjectId = objectId;
    }

    public BreachRewardBuyMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ObjectId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectId);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUInt();
    }
}