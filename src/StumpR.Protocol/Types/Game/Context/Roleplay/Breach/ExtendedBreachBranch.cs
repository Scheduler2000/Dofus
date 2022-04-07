using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ExtendedBreachBranch : BreachBranch
{
    public new const short Id = 9376;

    public ExtendedBreachBranch(sbyte room,
        int element,
        IEnumerable<MonsterInGroupLightInformations> bosses,
        double map,
        short score,
        short relativeScore,
        IEnumerable<MonsterInGroupLightInformations> monsters,
        IEnumerable<BreachReward> rewards,
        int modifier,
        uint prize)
    {
        Room = room;
        Element = element;
        Bosses = bosses;
        Map = map;
        Score = score;
        RelativeScore = relativeScore;
        Monsters = monsters;
        Rewards = rewards;
        Modifier = modifier;
        Prize = prize;
    }

    public ExtendedBreachBranch()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<BreachReward> Rewards { get; set; }

    public int Modifier { get; set; }

    public uint Prize { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Rewards.Count());
        foreach (BreachReward objectToSend in Rewards) objectToSend.Serialize(writer);
        writer.WriteVarInt(Modifier);
        writer.WriteVarUInt(Prize);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort rewardsCount = reader.ReadUShort();
        var rewards_ = new BreachReward[rewardsCount];

        for (var rewardsIndex = 0; rewardsIndex < rewardsCount; rewardsIndex++)
        {
            var objectToAdd = new BreachReward();
            objectToAdd.Deserialize(reader);
            rewards_[rewardsIndex] = objectToAdd;
        }
        Rewards = rewards_;
        Modifier = reader.ReadVarInt();
        Prize = reader.ReadVarUInt();
    }
}