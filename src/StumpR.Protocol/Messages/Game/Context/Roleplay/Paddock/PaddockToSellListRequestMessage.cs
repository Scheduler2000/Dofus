using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PaddockToSellListRequestMessage : Message
{
    public const uint Id = 456;

    public PaddockToSellListRequestMessage(ushort pageIndex)
    {
        PageIndex = pageIndex;
    }

    public PaddockToSellListRequestMessage()
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