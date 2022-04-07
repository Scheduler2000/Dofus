using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayPlayerFightRequestMessage : Message
{
    public const uint Id = 6364;

    public GameRolePlayPlayerFightRequestMessage(ulong targetId, short targetCellId, bool friendly)
    {
        TargetId = targetId;
        TargetCellId = targetCellId;
        Friendly = friendly;
    }

    public GameRolePlayPlayerFightRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong TargetId { get; set; }

    public short TargetCellId { get; set; }

    public bool Friendly { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(TargetId);
        writer.WriteShort(TargetCellId);
        writer.WriteBoolean(Friendly);
    }

    public override void Deserialize(IDataReader reader)
    {
        TargetId = reader.ReadVarULong();
        TargetCellId = reader.ReadShort();
        Friendly = reader.ReadBoolean();
    }
}