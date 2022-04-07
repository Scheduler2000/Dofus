using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaRegistrationStatusMessage : Message
{
    public const uint Id = 4323;

    public GameRolePlayArenaRegistrationStatusMessage(bool registered, sbyte step, int battleMode)
    {
        Registered = registered;
        Step = step;
        BattleMode = battleMode;
    }

    public GameRolePlayArenaRegistrationStatusMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Registered { get; set; }

    public sbyte Step { get; set; }

    public int BattleMode { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Registered);
        writer.WriteSByte(Step);
        writer.WriteInt(BattleMode);
    }

    public override void Deserialize(IDataReader reader)
    {
        Registered = reader.ReadBoolean();
        Step = reader.ReadSByte();
        BattleMode = reader.ReadInt();
    }
}