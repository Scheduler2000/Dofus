using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaRegisterMessage : Message
{
    public const uint Id = 5010;

    public GameRolePlayArenaRegisterMessage(int battleMode)
    {
        BattleMode = battleMode;
    }

    public GameRolePlayArenaRegisterMessage()
    {
    }

    public override uint MessageId => Id;

    public int BattleMode { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(BattleMode);
    }

    public override void Deserialize(IDataReader reader)
    {
        BattleMode = reader.ReadInt();
    }
}