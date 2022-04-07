using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightTriggerGlyphTrapMessage : AbstractGameActionMessage
{
    public new const uint Id = 1777;

    public GameActionFightTriggerGlyphTrapMessage(ushort actionId,
        double sourceId,
        short markId,
        ushort markImpactCell,
        double triggeringCharacterId,
        ushort triggeredSpellId)
    {
        ActionId = actionId;
        SourceId = sourceId;
        MarkId = markId;
        MarkImpactCell = markImpactCell;
        TriggeringCharacterId = triggeringCharacterId;
        TriggeredSpellId = triggeredSpellId;
    }

    public GameActionFightTriggerGlyphTrapMessage()
    {
    }

    public override uint MessageId => Id;

    public short MarkId { get; set; }

    public ushort MarkImpactCell { get; set; }

    public double TriggeringCharacterId { get; set; }

    public ushort TriggeredSpellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(MarkId);
        writer.WriteVarUShort(MarkImpactCell);
        writer.WriteDouble(TriggeringCharacterId);
        writer.WriteVarUShort(TriggeredSpellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        MarkId = reader.ReadShort();
        MarkImpactCell = reader.ReadVarUShort();
        TriggeringCharacterId = reader.ReadDouble();
        TriggeredSpellId = reader.ReadVarUShort();
    }
}