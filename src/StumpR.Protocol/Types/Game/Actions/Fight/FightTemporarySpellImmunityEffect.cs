using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightTemporarySpellImmunityEffect : AbstractFightDispellableEffect
{
    public new const short Id = 4141;

    public FightTemporarySpellImmunityEffect(uint uid,
        double targetId,
        short turnDuration,
        sbyte dispelable,
        ushort spellId,
        uint effectId,
        uint parentBoostUid,
        int immuneSpellId)
    {
        Uid = uid;
        TargetId = targetId;
        TurnDuration = turnDuration;
        Dispelable = dispelable;
        SpellId = spellId;
        EffectId = effectId;
        ParentBoostUid = parentBoostUid;
        ImmuneSpellId = immuneSpellId;
    }

    public FightTemporarySpellImmunityEffect()
    {
    }

    public override short TypeId => Id;

    public int ImmuneSpellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(ImmuneSpellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ImmuneSpellId = reader.ReadInt();
    }
}