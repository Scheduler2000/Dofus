using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayAggressionMessage : Message
{
    public const uint Id = 2660;

    public GameRolePlayAggressionMessage(ulong attackerId, ulong defenderId)
    {
        AttackerId = attackerId;
        DefenderId = defenderId;
    }

    public GameRolePlayAggressionMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong AttackerId { get; set; }

    public ulong DefenderId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(AttackerId);
        writer.WriteVarULong(DefenderId);
    }

    public override void Deserialize(IDataReader reader)
    {
        AttackerId = reader.ReadVarULong();
        DefenderId = reader.ReadVarULong();
    }
}