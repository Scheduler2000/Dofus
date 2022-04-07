using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class QuestActiveInformations
{
    public const short Id = 1975;

    public QuestActiveInformations(ushort questId)
    {
        QuestId = questId;
    }

    public QuestActiveInformations()
    {
    }

    public virtual short TypeId => Id;

    public ushort QuestId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(QuestId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        QuestId = reader.ReadVarUShort();
    }
}