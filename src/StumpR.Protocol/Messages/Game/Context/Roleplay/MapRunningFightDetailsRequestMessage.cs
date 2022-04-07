using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapRunningFightDetailsRequestMessage : Message
{
    public const uint Id = 8028;

    public MapRunningFightDetailsRequestMessage(ushort fightId)
    {
        FightId = fightId;
    }

    public MapRunningFightDetailsRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
    }
}