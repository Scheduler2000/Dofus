using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PaddockInstancesInformations : PaddockInformations
{
    public new const short Id = 3435;

    public PaddockInstancesInformations(ushort maxOutdoorMount, ushort maxItems, IEnumerable<PaddockBuyableInformations> paddocks)
    {
        MaxOutdoorMount = maxOutdoorMount;
        MaxItems = maxItems;
        Paddocks = paddocks;
    }

    public PaddockInstancesInformations()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<PaddockBuyableInformations> Paddocks { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) Paddocks.Count());

        foreach (PaddockBuyableInformations objectToSend in Paddocks)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort paddocksCount = reader.ReadUShort();
        var paddocks_ = new PaddockBuyableInformations[paddocksCount];

        for (var paddocksIndex = 0; paddocksIndex < paddocksCount; paddocksIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<PaddockBuyableInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            paddocks_[paddocksIndex] = objectToAdd;
        }
        Paddocks = paddocks_;
    }
}