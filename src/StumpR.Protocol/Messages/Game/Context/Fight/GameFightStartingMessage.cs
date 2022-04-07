using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightStartingMessage : Message
{
    public const uint Id = 2951;

    public GameFightStartingMessage(sbyte fightType, ushort fightId, double attackerId, double defenderId, bool containsBoss)
    {
        FightType = fightType;
        FightId = fightId;
        AttackerId = attackerId;
        DefenderId = defenderId;
        ContainsBoss = containsBoss;
    }

    public GameFightStartingMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte FightType { get; set; }

    public ushort FightId { get; set; }

    public double AttackerId { get; set; }

    public double DefenderId { get; set; }

    public bool ContainsBoss { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(FightType);
        writer.WriteVarUShort(FightId);
        writer.WriteDouble(AttackerId);
        writer.WriteDouble(DefenderId);
        writer.WriteBoolean(ContainsBoss);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightType = reader.ReadSByte();
        FightId = reader.ReadVarUShort();
        AttackerId = reader.ReadDouble();
        DefenderId = reader.ReadDouble();
        ContainsBoss = reader.ReadBoolean();
    }
}