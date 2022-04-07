using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayMonsterAngryAtPlayerMessage : Message
{
    public const uint Id = 465;

    public GameRolePlayMonsterAngryAtPlayerMessage(ulong playerId, double monsterGroupId, double angryStartTime, double attackTime)
    {
        PlayerId = playerId;
        MonsterGroupId = monsterGroupId;
        AngryStartTime = angryStartTime;
        AttackTime = attackTime;
    }

    public GameRolePlayMonsterAngryAtPlayerMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public double MonsterGroupId { get; set; }

    public double AngryStartTime { get; set; }

    public double AttackTime { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(PlayerId);
        writer.WriteDouble(MonsterGroupId);
        writer.WriteDouble(AngryStartTime);
        writer.WriteDouble(AttackTime);
    }

    public override void Deserialize(IDataReader reader)
    {
        PlayerId = reader.ReadVarULong();
        MonsterGroupId = reader.ReadDouble();
        AngryStartTime = reader.ReadDouble();
        AttackTime = reader.ReadDouble();
    }
}