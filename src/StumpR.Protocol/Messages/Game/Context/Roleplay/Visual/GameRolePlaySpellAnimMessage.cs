using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlaySpellAnimMessage : Message
{
    public const uint Id = 8430;

    public GameRolePlaySpellAnimMessage(ulong casterId, ushort targetCellId, ushort spellId, short spellLevel)
    {
        CasterId = casterId;
        TargetCellId = targetCellId;
        SpellId = spellId;
        SpellLevel = spellLevel;
    }

    public GameRolePlaySpellAnimMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong CasterId { get; set; }

    public ushort TargetCellId { get; set; }

    public ushort SpellId { get; set; }

    public short SpellLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(CasterId);
        writer.WriteVarUShort(TargetCellId);
        writer.WriteVarUShort(SpellId);
        writer.WriteShort(SpellLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        CasterId = reader.ReadVarULong();
        TargetCellId = reader.ReadVarUShort();
        SpellId = reader.ReadVarUShort();
        SpellLevel = reader.ReadShort();
    }
}