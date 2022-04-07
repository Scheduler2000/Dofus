using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightTemporarySpellBoostEffect : FightTemporaryBoostEffect
{
    public new const short Id = 540;

    public FightTemporarySpellBoostEffect(uint uid,
        double targetId,
        short turnDuration,
        sbyte dispelable,
        ushort spellId,
        uint effectId,
        uint parentBoostUid,
        int delta,
        ushort boostedSpellId)
    {
        Uid = uid;
        TargetId = targetId;
        TurnDuration = turnDuration;
        Dispelable = dispelable;
        SpellId = spellId;
        EffectId = effectId;
        ParentBoostUid = parentBoostUid;
        Delta = delta;
        BoostedSpellId = boostedSpellId;
    }

    public FightTemporarySpellBoostEffect()
    {
    }

    public override short TypeId => Id;

    public ushort BoostedSpellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(BoostedSpellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        BoostedSpellId = reader.ReadVarUShort();
    }
}