using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightSpectatorJoinMessage : GameFightJoinMessage
{
    public new const uint Id = 6927;

    public GameFightSpectatorJoinMessage(bool isTeamPhase,
        bool canBeCancelled,
        bool canSayReady,
        bool isFightStarted,
        short timeMaxBeforeFightStart,
        sbyte fightType,
        IEnumerable<NamedPartyTeam> namedPartyTeams)
    {
        IsTeamPhase = isTeamPhase;
        CanBeCancelled = canBeCancelled;
        CanSayReady = canSayReady;
        IsFightStarted = isFightStarted;
        TimeMaxBeforeFightStart = timeMaxBeforeFightStart;
        FightType = fightType;
        NamedPartyTeams = namedPartyTeams;
    }

    public GameFightSpectatorJoinMessage()
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