using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectEffect
{
    public const short Id = 5685;

    public ObjectEffect(ushort actionId)
    {
        ActionId = actionId;
    }

    public ObjectEffect()
    {
    }

    public virtual short TypeId => Id;

    public ushort ActionId { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ActionId);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ActionId = reader.ReadVarUShort();
    }
}