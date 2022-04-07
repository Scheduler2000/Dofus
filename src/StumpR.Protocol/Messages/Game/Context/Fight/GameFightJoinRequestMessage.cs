using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightJoinRequestMessage : Message
{
    public const uint Id = 6519;

    public GameFightJoinRequestMessage(double fighterId, ushort fightId)
    {
        FighterId = fighterId;
        FightId = fightId;
    }

    public GameFightJoinRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public double FighterId { get; set; }

    public ushort FightId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(FighterId);
        writer.WriteVarUShort(FightId);
    }

    public override void Deserialize(IDataReader reader)
    {
        FighterId = reader.ReadDouble();
        FightId = reader.ReadVarUShort();
    }
}