using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class InteractiveUsedMessage : Message
{
    public const uint Id = 4971;

    public InteractiveUsedMessage(ulong entityId, uint elemId, ushort skillId, ushort duration, bool canMove)
    {
        EntityId = entityId;
        ElemId = elemId;
        SkillId = skillId;
        Duration = duration;
        CanMove = canMove;
    }

    public InteractiveUsedMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong EntityId { get; set; }

    public uint ElemId { get; set; }

    public ushort SkillId { get; set; }

    public ushort Duration { get; set; }

    public bool CanMove { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(EntityId);
        writer.WriteVarUInt(ElemId);
        writer.WriteVarUShort(SkillId);
        writer.WriteVarUShort(Duration);
        writer.WriteBoolean(CanMove);
    }

    public override void Deserialize(IDataReader reader)
    {
        EntityId = reader.ReadVarULong();
        ElemId = reader.ReadVarUInt();
        SkillId = reader.ReadVarUShort();
        Duration = reader.ReadVarUShort();
        CanMove = reader.ReadBoolean();
    }
}