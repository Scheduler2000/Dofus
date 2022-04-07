using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaFighterStatusMessage : Message
{
    public const uint Id = 5125;

    public GameRolePlayArenaFighterStatusMessage(ushort fightId, double playerId, bool accepted)
    {
        FightId = fightId;
        PlayerId = playerId;
        Accepted = accepted;
    }

    public GameRolePlayArenaFighterStatusMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightId { get; set; }

    public double PlayerId { get; set; }

    public bool Accepted { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
        writer.WriteDouble(PlayerId);
        writer.WriteBoolean(Accepted);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
        PlayerId = reader.ReadDouble();
        Accepted = reader.ReadBoolean();
    }
}