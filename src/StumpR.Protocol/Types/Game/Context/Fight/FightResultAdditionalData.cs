using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightResultAdditionalData
{
    public const short Id = 6654;

    public virtual short TypeId => Id;

    public virtual void Serialize(IDataWriter writer)
    {
    }

    public virtual void Deserialize(IDataReader reader)
    {
    }
}