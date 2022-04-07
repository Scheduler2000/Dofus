using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayMonsterNotAngryAtPlayerMessage : Message
{
    public const uint Id = 7726;

    public GameRolePlayMonsterNotAngryAtPlayerMessage(ulong playerId, double monsterGroupId)
    {
        PlayerId = playerId;
        MonsterGroupId = monsterGroupId;
    }

    public GameRolePlayMonsterNotAngryAtPlayerMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public double MonsterGroupId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(PlayerId);
        writer.WriteDouble(MonsterGroupId);
    }

    public override void Deserialize(IDataReader reader)
    {
        PlayerId = reader.ReadVarULong();
        MonsterGroupId = reader.ReadDouble();
    }
}