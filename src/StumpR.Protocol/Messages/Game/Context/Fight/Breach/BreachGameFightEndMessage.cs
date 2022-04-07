using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachGameFightEndMessage : GameFightEndMessage
{
    public new const uint Id = 7323;

    public BreachGameFightEndMessage(int duration,
        short rewardRate,
        short lootShareLimitMalus,
        IEnumerable<FightResultListEntry> results,
        IEnumerable<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes,
        int budget)
    {
        Duration = duration;
        RewardRate = rewardRate;
        LootShareLimitMalus = lootShareLimitMalus;
        Results = results;
        NamedPartyTeamsOutcomes = namedPartyTeamsOutcomes;
        Budget = budget;
    }

    public BreachGameFightEndMessage()
    {
    }

    public override uint MessageId => Id;

    public int Budget { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(Budget);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Budget = reader.ReadInt();
    }
}