using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismFightDefenderLeaveMessage : Message
{
    public const uint Id = 9481;

    public PrismFightDefenderLeaveMessage(ushort subAreaId, ushort fightId, ulong fighterToRemoveId)
    {
        SubAreaId = subAreaId;
        FightId = fightId;
        FighterToRemoveId = fighterToRemoveId;
    }

    public PrismFightDefenderLeaveMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SubAreaId { get; set; }

    public ushort FightId { get; set; }

    public ulong FighterToRemoveId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SubAreaId);
        writer.WriteVarUShort(FightId);
        writer.WriteVarULong(FighterToRemoveId);
    }

    public override void Deserialize(IDataReader reader)
    {
        SubAreaId = reader.ReadVarUShort();
        FightId = reader.ReadVarUShort();
        FighterToRemoveId = reader.ReadVarULong();
    }
}