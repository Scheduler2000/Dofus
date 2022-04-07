using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightRemoveTeamMemberMessage : Message
{
    public const uint Id = 6697;

    public GameFightRemoveTeamMemberMessage(ushort fightId, sbyte teamId, double charId)
    {
        FightId = fightId;
        TeamId = teamId;
        CharId = charId;
    }

    public GameFightRemoveTeamMemberMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightId { get; set; }

    public sbyte TeamId { get; set; }

    public double CharId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
        writer.WriteSByte(TeamId);
        writer.WriteDouble(CharId);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
        TeamId = reader.ReadSByte();
        CharId = reader.ReadDouble();
    }
}