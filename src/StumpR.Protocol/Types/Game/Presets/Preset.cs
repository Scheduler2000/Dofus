using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class Preset
{
    public const short Id = 6024;

    public Preset(short objectId)
    {
        ObjectId = objectId;
    }

    public Preset()
    {
    }

    public virtual short TypeId => Id;

    public short ObjectId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort(ObjectId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadShort();
    }
}