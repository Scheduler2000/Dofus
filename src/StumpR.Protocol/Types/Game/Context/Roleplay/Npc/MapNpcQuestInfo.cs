using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class MapNpcQuestInfo
{
    public const short Id = 7429;

    public MapNpcQuestInfo(double mapId, IEnumerable<int> npcsIdsWithQuest, IEnumerable<GameRolePlayNpcQuestFlag> questFlags)
    {
        MapId = mapId;
        NpcsIdsWithQuest = npcsIdsWithQuest;
        QuestFlags = questFlags;
    }

    public MapNpcQuestInfo()
    {
    }

    public virtual short TypeId => Id;

    public double MapId { get; set; }

    public IEnumerable<int> NpcsIdsWithQuest { get; set; }

    public IEnumerable<GameRolePlayNpcQuestFlag> QuestFlags { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(MapId);
        writer.WriteShort((short) NpcsIdsWithQuest.Count());
        foreach (int objectToSend in NpcsIdsWithQuest) writer.WriteInt(objectToSend);
        writer.WriteShort((short) QuestFlags.Count());
        foreach (GameRolePlayNpcQuestFlag objectToSend in QuestFlags) objectToSend.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        MapId = reader.ReadDouble();
        ushort npcsIdsWithQuestCount = reader.ReadUShort();
        var npcsIdsWithQuest_ = new int[npcsIdsWithQuestCount];

        for (var npcsIdsWithQuestIndex = 0; npcsIdsWithQuestIndex < npcsIdsWithQuestCount; npcsIdsWithQuestIndex++)
            npcsIdsWithQuest_[npcsIdsWithQuestIndex] = reader.ReadInt();
        NpcsIdsWithQuest = npcsIdsWithQuest_;
        ushort questFlagsCount = reader.ReadUShort();
        var questFlags_ = new GameRolePlayNpcQuestFlag[questFlagsCount];

        for (var questFlagsIndex = 0; questFlagsIndex < questFlagsCount; questFlagsIndex++)
        {
            var objectToAdd = new GameRolePlayNpcQuestFlag();
            objectToAdd.Deserialize(reader);
            questFlags_[questFlagsIndex] = objectToAdd;
        }
        QuestFlags = questFlags_;
    }
}