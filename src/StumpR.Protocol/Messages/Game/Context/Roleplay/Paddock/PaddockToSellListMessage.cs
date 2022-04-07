using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PaddockToSellListMessage : Message
{
    public const uint Id = 3451;

    public PaddockToSellListMessage(ushort pageIndex, ushort totalPage, IEnumerable<PaddockInformationsForSell> paddockList)
    {
        PageIndex = pageIndex;
        TotalPage = totalPage;
        PaddockList = paddockList;
    }

    public PaddockToSellListMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort PageIndex { get; set; }

    public ushort TotalPage { get; set; }

    public IEnumerable<PaddockInformationsForSell> PaddockList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(PageIndex);
        writer.WriteVarUShort(TotalPage);
        writer.WriteShort((short) PaddockList.Count());
        foreach (PaddockInformationsForSell objectToSend in PaddockList) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        PageIndex = reader.ReadVarUShort();
        TotalPage = reader.ReadVarUShort();
        ushort paddockListCount = reader.ReadUShort();
        var paddockList_ = new PaddockInformationsForSell[paddockListCount];

        for (var paddockListIndex = 0; paddockListIndex < paddockListCount; paddockListIndex++)
        {
            var objectToAdd = new PaddockInformationsForSell();
            objectToAdd.Deserialize(reader);
            paddockList_[paddockListIndex] = objectToAdd;
        }
        PaddockList = paddockList_;
    }
}