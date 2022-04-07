using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PaddockBuyableInformations
{
    public const short Id = 3536;

    public PaddockBuyableInformations(ulong price, bool locked)
    {
        Price = price;
        Locked = locked;
    }

    public PaddockBuyableInformations()
    {
    }

    public virtual short TypeId => Id;

    public ulong Price { get; set; }

    public bool Locked { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(Price);
        writer.WriteBoolean(Locked);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Price = reader.ReadVarULong();
        Locked = reader.ReadBoolean();
    }
}