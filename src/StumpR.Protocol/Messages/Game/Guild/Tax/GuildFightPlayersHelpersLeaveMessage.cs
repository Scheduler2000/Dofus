using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildFightPlayersHelpersLeaveMessage : Message
{
    public const uint Id = 5749;

    public GuildFightPlayersHelpersLeaveMessage(double fightId, ulong playerId)
    {
        FightId = fightId;
        PlayerId = playerId;
    }

    public GuildFightPlayersHelpersLeaveMessage()
    {
    }

    public override uint MessageId => Id;

    public double FightId { get; set; }

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(FightId);
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadDouble();
        PlayerId = reader.ReadVarULong();
    }
}