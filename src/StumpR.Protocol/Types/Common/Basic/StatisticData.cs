using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class StatisticData
{
    public const short Id = 9162;

    public virtual short TypeId => Id;

    public virtual void Serialize(IDataWriter writer)
    {
    }

    public virtual void Deserialize(IDataReader reader)
    {
    }
}