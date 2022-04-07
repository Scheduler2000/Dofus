using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseToSellListRequestMessage : Message
{
    public const uint Id = 1679;

    public HouseToSellListRequestMessage(ushort pageIndex)
    {
        PageIndex = pageIndex;
    }

    public HouseToSellListRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort PageIndex { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(PageIndex);
    }

    public override void Deserialize(IDataReader reader)
    {
        PageIndex = reader.ReadVarUShort();
    }
}