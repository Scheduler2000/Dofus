using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class RefreshFollowedQuestsOrderRequestMessage : Message
{
    public const uint Id = 1088;

    public RefreshFollowedQuestsOrderRequestMessage(IEnumerable<ushort> quests)
    {
        Quests = quests;
    }

    public RefreshFollowedQuestsOrderRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> Quests { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Quests.Count());
        foreach (ushort objectToSend in Quests) writer.WriteVarUShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort questsCount = reader.ReadUShort();
        var quests_ = new ushort[questsCount];
        for (var questsIndex = 0; questsIndex < questsCount; questsIndex++) quests_[questsIndex] = reader.ReadVarUShort();
        Quests = quests_;
    }
}