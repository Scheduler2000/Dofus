using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightUpdateTeamMessage : Message
{
    public const uint Id = 9785;

    public GameFightUpdateTeamMessage(ushort fightId, FightTeamInformations team)
    {
        FightId = fightId;
        Team = team;
    }

    public GameFightUpdateTeamMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightId { get; set; }

    public FightTeamInformations Team { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
        Team.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
        Team = new FightTeamInformations();
        Team.Deserialize(reader);
    }
}