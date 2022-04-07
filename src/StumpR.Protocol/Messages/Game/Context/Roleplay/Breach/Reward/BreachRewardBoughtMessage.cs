using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachRewardBoughtMessage : Message
{
    public const uint Id = 3950;

    public BreachRewardBoughtMessage(uint objectId, bool bought)
    {
        ObjectId = objectId;
        Bought = bought;
    }

    public BreachRewardBoughtMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ObjectId { get; set; }

    public bool Bought { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectId);
        writer.WriteBoolean(Bought);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUInt();
        Bought = reader.ReadBoolean();
    }
}