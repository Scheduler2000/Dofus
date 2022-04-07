using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ExtendedLockedBreachBranch : ExtendedBreachBranch
{
    public new const short Id = 169;

    public ExtendedLockedBreachBranch(sbyte room,
        int element,
        IEnumerable<MonsterInGroupLightInformations> bosses,
        double map,
        short score,
        short relativeScore,
        IEnumerable<MonsterInGroupLightInformations> monsters,
        IEnumerable<BreachReward> rewards,
        int modifier,
        uint prize,
        uint unlockPrice)
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
        UnlockPrice = unlockPrice;
    }

    public ExtendedLockedBreachBranch()
    {
    }

    public override short TypeId => Id;

    public uint UnlockPrice { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(UnlockPrice);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        UnlockPrice = reader.ReadVarUInt();
    }
}