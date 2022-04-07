using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightEndMessage : Message
{
    public const uint Id = 5098;

    public GameFightEndMessage(int duration,
        short rewardRate,
        short lootShareLimitMalus,
        IEnumerable<FightResultListEntry> results,
        IEnumerable<NamedPartyTeamWithOutcome> namedPartyTeamsOutcomes)
    {
        Duration = duration;
        RewardRate = rewardRate;
        LootShareLimitMalus = lootShareLimitMalus;
        Results = results;
        NamedPartyTeamsOutcomes = namedPartyTeamsOutcomes;
    }

    public GameFightEndMessage()
    {
    }

    public override uint MessageId => Id;

    public int Duration { get; set; }

    public short RewardRate { get; set; }

    public short LootShareLimitMalus { get; set; }

    public IEnumerable<FightResultListEntry> Results { get; set; }

    public IEnumerable<NamedPartyTeamWithOutcome> NamedPartyTeamsOutcomes { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(Duration);
        writer.WriteVarShort(RewardRate);
        writer.WriteShort(LootShareLimitMalus);
        writer.WriteShort((short) Results.Count());

        foreach (FightResultListEntry objectToSend in Results)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) NamedPartyTeamsOutcomes.Count());
        foreach (NamedPartyTeamWithOutcome objectToSend in NamedPartyTeamsOutcomes) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Duration = reader.ReadInt();
        RewardRate = reader.ReadVarShort();
        LootShareLimitMalus = reader.ReadShort();
        ushort resultsCount = reader.ReadUShort();
        var results_ = new FightResultListEntry[resultsCount];

        for (var resultsIndex = 0; resultsIndex < resultsCount; resultsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<FightResultListEntry>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            results_[resultsIndex] = objectToAdd;
        }
        Results = results_;
        ushort namedPartyTeamsOutcomesCount = reader.ReadUShort();
        var namedPartyTeamsOutcomes_ = new NamedPartyTeamWithOutcome[namedPartyTeamsOutcomesCount];

        for (var namedPartyTeamsOutcomesIndex = 0;
             namedPartyTeamsOutcomesIndex < namedPartyTeamsOutcomesCount;
             namedPartyTeamsOutcomesIndex++)
        {
            var objectToAdd = new NamedPartyTeamWithOutcome();
            objectToAdd.Deserialize(reader);
            namedPartyTeamsOutcomes_[namedPartyTeamsOutcomesIndex] = objectToAdd;
        }
        NamedPartyTeamsOutcomes = namedPartyTeamsOutcomes_;
    }
}