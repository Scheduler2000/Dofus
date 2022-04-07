using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightTemporaryBoostEffect : AbstractFightDispellableEffect
{
    public new const short Id = 7366;

    public FightTemporaryBoostEffect(uint uid,
        double targetId,
        short turnDuration,
        sbyte dispelable,
        ushort spellId,
        uint effectId,
        uint parentBoostUid,
        int delta)
    {
        Uid = uid;
        TargetId = targetId;
        TurnDuration = turnDuration;
        Dispelable = dispelable;
        SpellId = spellId;
        EffectId = effectId;
        ParentBoostUid = parentBoostUid;
        Delta = delta;
    }

    public FightTemporaryBoostEffect()
    {
    }

    public override short TypeId => Id;

    public int Delta { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(Delta);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Delta = reader.ReadInt();
    }
}