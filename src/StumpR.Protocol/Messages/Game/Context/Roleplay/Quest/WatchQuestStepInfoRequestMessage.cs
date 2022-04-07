using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class WatchQuestStepInfoRequestMessage : QuestStepInfoRequestMessage
{
    public new const uint Id = 8640;

    public WatchQuestStepInfoRequestMessage(ushort questId, ulong playerId)
    {
        QuestId = questId;
        PlayerId = playerId;
    }

    public WatchQuestStepInfoRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerId = reader.ReadVarULong();
    }
}