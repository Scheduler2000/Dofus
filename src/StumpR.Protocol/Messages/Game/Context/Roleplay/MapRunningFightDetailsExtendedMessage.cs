using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapRunningFightDetailsExtendedMessage : MapRunningFightDetailsMessage
{
    public new const uint Id = 9456;

    public MapRunningFightDetailsExtendedMessage(ushort fightId,
        IEnumerable<GameFightFighterLightInformations> attackers,
        IEnumerable<GameFightFighterLightInformations> defenders,
        IEnumerable<NamedPartyTeam> namedPartyTeams)
    {
        FightId = fightId;
        Attackers = attackers;
        Defenders = defenders;
        NamedPartyTeams = namedPartyTeams;
    }

    public MapRunningFightDetailsExtendedMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<NamedPartyTeam> NamedPartyTeams { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) NamedPartyTeams.Count());
        foreach (NamedPartyTeam objectToSend in NamedPartyTeams) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort namedPartyTeamsCount = reader.ReadUShort();
        var namedPartyTeams_ = new NamedPartyTeam[namedPartyTeamsCount];

        for (var namedPartyTeamsIndex = 0; namedPartyTeamsIndex < namedPartyTeamsCount; namedPartyTeamsIndex++)
        {
            var objectToAdd = new NamedPartyTeam();
            objectToAdd.Deserialize(reader);
            namedPartyTeams_[namedPartyTeamsIndex] = objectToAdd;
        }
        NamedPartyTeams = namedPartyTeams_;
    }
}