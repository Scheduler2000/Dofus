using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class WatchQuestStepInfoMessage : QuestStepInfoMessage
{
    public new const uint Id = 2727;

    public WatchQuestStepInfoMessage(QuestActiveInformations infos, ulong playerId)
    {
        Infos = infos;
        PlayerId = playerId;
    }

    public WatchQuestStepInfoMessage()
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