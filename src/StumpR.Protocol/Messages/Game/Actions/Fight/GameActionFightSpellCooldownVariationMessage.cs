using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightSpellCooldownVariationMessage : AbstractGameActionMessage
{
    public new const uint Id = 2288;

    public GameActionFightSpellCooldownVariationMessage(ushort actionId, double sourceId, double targetId, ushort spellId, short value)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        SpellId = spellId;
        Value = value;
    }

    public GameActionFightSpellCooldownVariationMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public ushort SpellId { get; set; }

    public short Value { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteVarUShort(SpellId);
        writer.WriteVarShort(Value);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        SpellId = reader.ReadVarUShort();
        Value = reader.ReadVarShort();
    }
}