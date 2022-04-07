using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AbstractSocialGroupInfos
{
    public const short Id = 6359;

    public virtual short TypeId => Id;

    public virtual void Serialize(IDataWriter writer)
    {
    }

    public virtual void Deserialize(IDataReader reader)
    {
    }
}