using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AbstractPlayerSearchInformation
{
    public const short Id = 1294;

    public virtual short TypeId => Id;

    public virtual void Serialize(IDataWriter writer)
    {
    }

    public virtual void Deserialize(IDataReader reader)
    {
    }
}