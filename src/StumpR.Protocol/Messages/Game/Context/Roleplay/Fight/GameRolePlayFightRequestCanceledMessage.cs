using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayFightRequestCanceledMessage : Message
{
    public const uint Id = 4478;

    public GameRolePlayFightRequestCanceledMessage(ushort fightId, double sourceId, double targetId)
    {
        FightId = fightId;
        SourceId = sourceId;
        TargetId = targetId;
    }

    public GameRolePlayFightRequestCanceledMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightId { get; set; }

    public double SourceId { get; set; }

    public double TargetId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
        writer.WriteDouble(SourceId);
        writer.WriteDouble(TargetId);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
        SourceId = reader.ReadDouble();
        TargetId = reader.ReadDouble();
    }
}