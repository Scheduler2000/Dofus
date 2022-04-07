using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightSpellCastMessage : AbstractGameActionFightTargetedAbilityMessage
{
    public new const uint Id = 2648;

    public GameActionFightSpellCastMessage(ushort actionId,
        double sourceId,
        bool silentCast,
        bool verboseCast,
        double targetId,
        short destinationCellId,
        sbyte critical,
        ushort spellId,
        short spellLevel,
        IEnumerable<short> portalsIds)
    {
        ActionId = actionId;
        SourceId = sourceId;
        SilentCast = silentCast;
        VerboseCast = verboseCast;
        TargetId = targetId;
        DestinationCellId = destinationCellId;
        Critical = critical;
        SpellId = spellId;
        SpellLevel = spellLevel;
        PortalsIds = portalsIds;
    }

    public GameActionFightSpellCastMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SpellId { get; set; }

    public short SpellLevel { get; set; }

    public IEnumerable<short> PortalsIds { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(SpellId);
        writer.WriteShort(SpellLevel);
        writer.WriteShort((short) PortalsIds.Count());
        foreach (short objectToSend in PortalsIds) writer.WriteShort(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        SpellId = reader.ReadVarUShort();
        SpellLevel = reader.ReadShort();
        ushort portalsIdsCount = reader.ReadUShort();
        var portalsIds_ = new short[portalsIdsCount];

        for (var portalsIdsIndex = 0; portalsIdsIndex < portalsIdsCount; portalsIdsIndex++)
            portalsIds_[portalsIdsIndex] = reader.ReadShort();
        PortalsIds = portalsIds_;
    }
}