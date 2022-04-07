using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaRegistrationWarningMessage : Message
{
    public const uint Id = 1528;

    public GameRolePlayArenaRegistrationWarningMessage(int battleMode)
    {
        BattleMode = battleMode;
    }

    public GameRolePlayArenaRegistrationWarningMessage()
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