using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameRolePlayNpcQuestFlag
{
    public const short Id = 3944;

    public GameRolePlayNpcQuestFlag(IEnumerable<ushort> questsToValidId, IEnumerable<ushort> questsToStartId)
    {
        QuestsToValidId = questsToValidId;
        QuestsToStartId = questsToStartId;
    }

    public GameRolePlayNpcQuestFlag()
    {
    }

    public virtual short TypeId => Id;

    public IEnumerable<ushort> QuestsToValidId { get; set; }

    public IEnumerable<ushort> QuestsToStartId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) QuestsToValidId.Count());
        foreach (ushort objectToSend in QuestsToValidId) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) QuestsToStartId.Count());
        foreach (ushort objectToSend in QuestsToStartId) writer.WriteVarUShort(objectToSend);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ushort questsToValidIdCount = reader.ReadUShort();
        var questsToValidId_ = new ushort[questsToValidIdCount];

        for (var questsToValidIdIndex = 0; questsToValidIdIndex < questsToValidIdCount; questsToValidIdIndex++)
            questsToValidId_[questsToValidIdIndex] = reader.ReadVarUShort();
        QuestsToValidId = questsToValidId_;
        ushort questsToStartIdCount = reader.ReadUShort();
        var questsToStartId_ = new ushort[questsToStartIdCount];

        for (var questsToStartIdIndex = 0; questsToStartIdIndex < questsToStartIdCount; questsToStartIdIndex++)
            questsToStartId_[questsToStartIdIndex] = reader.ReadVarUShort();
        QuestsToStartId = questsToStartId_;
    }
}