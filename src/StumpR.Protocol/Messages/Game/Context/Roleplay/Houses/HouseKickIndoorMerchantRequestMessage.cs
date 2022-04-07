using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseKickIndoorMerchantRequestMessage : Message
{
    public const uint Id = 8862;

    public HouseKickIndoorMerchantRequestMessage(ushort cellId)
    {
        CellId = cellId;
    }

    public HouseKickIndoorMerchantRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort CellId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(CellId);
    }

    public override void Deserialize(IDataReader reader)
    {
        CellId = reader.ReadVarUShort();
    }
}