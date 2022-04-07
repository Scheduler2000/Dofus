using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightTriggeredEffect : AbstractFightDispellableEffect
{
    public new const short Id = 1349;

    public FightTriggeredEffect(uint uid,
        double targetId,
        short turnDuration,
        sbyte dispelable,
        ushort spellId,
        uint effectId,
        uint parentBoostUid,
        int param1,
        int param2,
        int param3,
        short delay)
    {
        Uid = uid;
        TargetId = targetId;
        TurnDuration = turnDuration;
        Dispelable = dispelable;
        SpellId = spellId;
        EffectId = effectId;
        ParentBoostUid = parentBoostUid;
        Param1 = param1;
        Param2 = param2;
        Param3 = param3;
        Delay = delay;
    }

    public FightTriggeredEffect()
    {
    }

    public override short TypeId => Id;

    public int Param1 { get; set; }

    public int Param2 { get; set; }

    public int Param3 { get; set; }

    public short Delay { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(Param1);
        writer.WriteInt(Param2);
        writer.WriteInt(Param3);
        writer.WriteShort(Delay);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Param1 = reader.ReadInt();
        Param2 = reader.ReadInt();
        Param3 = reader.ReadInt();
        Delay = reader.ReadShort();
    }
}