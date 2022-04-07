using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightCloseCombatMessage : AbstractGameActionFightTargetedAbilityMessage
{
    public new const uint Id = 9973;

    public GameActionFightCloseCombatMessage(ushort actionId,
        double sourceId,
        bool silentCast,
        bool verboseCast,
        double targetId,
        short destinationCellId,
        sbyte critical,
        ushort weaponGenericId)
    {
        ActionId = actionId;
        SourceId = sourceId;
        SilentCast = silentCast;
        VerboseCast = verboseCast;
        TargetId = targetId;
        DestinationCellId = destinationCellId;
        Critical = critical;
        WeaponGenericId = weaponGenericId;
    }

    public GameActionFightCloseCombatMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort WeaponGenericId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(WeaponGenericId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        WeaponGenericId = reader.ReadVarUShort();
    }
}