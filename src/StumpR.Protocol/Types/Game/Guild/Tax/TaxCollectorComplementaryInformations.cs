using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TaxCollectorComplementaryInformations
{
    public const short Id = 9875;

    public virtual short TypeId => Id;

    public virtual void Serialize(IDataWriter writer)
    {
    }

    public virtual void Deserialize(IDataReader reader)
    {
    }
}