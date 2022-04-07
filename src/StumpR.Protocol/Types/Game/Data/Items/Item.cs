using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class Item
{
    public const short Id = 842;

    public virtual short TypeId => Id;

    public virtual void Serialize(IDataWriter writer)
    {
    }

    public virtual void Deserialize(IDataReader reader)
    {
    }
}