using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HumanOption
{
    public const short Id = 693;

    public virtual short TypeId => Id;

    public virtual void Serialize(IDataWriter writer)
    {
    }

    public virtual void Deserialize(IDataReader reader)
    {
    }
}