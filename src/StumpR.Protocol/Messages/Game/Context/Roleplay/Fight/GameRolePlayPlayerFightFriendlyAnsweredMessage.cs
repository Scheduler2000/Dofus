using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayPlayerFightFriendlyAnsweredMessage : Message
{
    public const uint Id = 5417;

    public GameRolePlayPlayerFightFriendlyAnsweredMessage(ushort fightId, ulong sourceId, ulong targetId, bool accept)
    {
        FightId = fightId;
        SourceId = sourceId;
        TargetId = targetId;
        Accept = accept;
    }

    public GameRolePlayPlayerFightFriendlyAnsweredMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightId { get; set; }

    public ulong SourceId { get; set; }

    public ulong TargetId { get; set; }

    public bool Accept { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
        writer.WriteVarULong(SourceId);
        writer.WriteVarULong(TargetId);
        writer.WriteBoolean(Accept);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
        SourceId = reader.ReadVarULong();
        TargetId = reader.ReadVarULong();
        Accept = reader.ReadBoolean();
    }
}