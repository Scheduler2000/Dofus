using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TreasureHuntStep
{
    public const short Id = 7141;

    public virtual short TypeId => Id;

    public virtual void Serialize(IDataWriter writer)
    {
    }

    public virtual void Deserialize(IDataReader reader)
    {
    }
}