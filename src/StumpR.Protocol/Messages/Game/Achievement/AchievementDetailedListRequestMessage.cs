using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AchievementDetailedListRequestMessage : Message
{
    public const uint Id = 5957;

    public AchievementDetailedListRequestMessage(ushort categoryId)
    {
        CategoryId = categoryId;
    }

    public AchievementDetailedListRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort CategoryId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(CategoryId);
    }

    public override void Deserialize(IDataReader reader)
    {
        CategoryId = reader.ReadVarUShort();
    }
}