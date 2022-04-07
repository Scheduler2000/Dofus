using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightSpellImmunityMessage : AbstractGameActionMessage
{
    public new const uint Id = 7640;

    public GameActionFightSpellImmunityMessage(ushort actionId, double sourceId, double targetId, ushort spellId)
    {
        ActionId = actionId;
        SourceId = sourceId;
        TargetId = targetId;
        SpellId = spellId;
    }

    public GameActionFightSpellImmunityMessage()
    {
    }

    public override uint MessageId => Id;

    public double TargetId { get; set; }

    public ushort SpellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(TargetId);
        writer.WriteVarUShort(SpellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        TargetId = reader.ReadDouble();
        SpellId = reader.ReadVarUShort();
    }
}