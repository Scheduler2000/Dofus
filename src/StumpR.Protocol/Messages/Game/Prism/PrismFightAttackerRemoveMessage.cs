using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismFightAttackerRemoveMessage : Message
{
    public const uint Id = 300;

    public PrismFightAttackerRemoveMessage(ushort subAreaId, ushort fightId, ulong fighterToRemoveId)
    {
        SubAreaId = subAreaId;
        FightId = fightId;
        FighterToRemoveId = fighterToRemoveId;
    }

    public PrismFightAttackerRemoveMessage()
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