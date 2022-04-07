using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HouseToSellListMessage : Message
{
    public const uint Id = 4515;

    public HouseToSellListMessage(ushort pageIndex, ushort totalPage, IEnumerable<HouseInformationsForSell> houseList)
    {
        PageIndex = pageIndex;
        TotalPage = totalPage;
        HouseList = houseList;
    }

    public HouseToSellListMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort PageIndex { get; set; }

    public ushort TotalPage { get; set; }

    public IEnumerable<HouseInformationsForSell> HouseList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(PageIndex);
        writer.WriteVarUShort(TotalPage);
        writer.WriteShort((short) HouseList.Count());
        foreach (HouseInformationsForSell objectToSend in HouseList) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        PageIndex = reader.ReadVarUShort();
        TotalPage = reader.ReadVarUShort();
        ushort houseListCount = reader.ReadUShort();
        var houseList_ = new HouseInformationsForSell[houseListCount];

        for (var houseListIndex = 0; houseListIndex < houseListCount; houseListIndex++)
        {
            var objectToAdd = new HouseInformationsForSell();
            objectToAdd.Deserialize(reader);
            houseList_[houseListIndex] = objectToAdd;
        }
        HouseList = houseList_;
    }
}