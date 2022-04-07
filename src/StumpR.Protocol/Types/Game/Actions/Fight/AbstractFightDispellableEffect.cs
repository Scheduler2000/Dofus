using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AbstractFightDispellableEffect
{
    public const short Id = 1657;

    public AbstractFightDispellableEffect(uint uid,
        double targetId,
        short turnDuration,
        sbyte dispelable,
        ushort spellId,
        uint effectId,
        uint parentBoostUid)
    {
        Uid = uid;
        TargetId = targetId;
        TurnDuration = turnDuration;
        Dispelable = dispelable;
        SpellId = spellId;
        EffectId = effectId;
        ParentBoostUid = parentBoostUid;
    }

    public AbstractFightDispellableEffect()
    {
    }

    public virtual short TypeId => Id;

    public uint Uid { get; set; }

    public double TargetId { get; set; }

    public short TurnDuration { get; set; }

    public sbyte Dispelable { get; set; }

    public ushort SpellId { get; set; }

    public uint EffectId { get; set; }

    public uint ParentBoostUid { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(Uid);
        writer.WriteDouble(TargetId);
        writer.WriteShort(TurnDuration);
        writer.WriteSByte(Dispelable);
        writer.WriteVarUShort(SpellId);
        writer.WriteVarUInt(EffectId);
        writer.WriteVarUInt(ParentBoostUid);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Uid = reader.ReadVarUInt();
        TargetId = reader.ReadDouble();
        TurnDuration = reader.ReadShort();
        Dispelable = reader.ReadSByte();
        SpellId = reader.ReadVarUShort();
        EffectId = reader.ReadVarUInt();
        ParentBoostUid = reader.ReadVarUInt();
    }
}