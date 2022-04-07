using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayAttackMonsterRequestMessage : Message
{
    public const uint Id = 3767;

    public GameRolePlayAttackMonsterRequestMessage(double monsterGroupId)
    {
        MonsterGroupId = monsterGroupId;
    }

    public GameRolePlayAttackMonsterRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public double MonsterGroupId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(MonsterGroupId);
    }

    public override void Deserialize(IDataReader reader)
    {
        MonsterGroupId = reader.ReadDouble();
    }
}