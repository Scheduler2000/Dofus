using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class MountInformationsForPaddock
{
    public const short Id = 1513;

    public MountInformationsForPaddock(ushort modelId, string name, string ownerName)
    {
        ModelId = modelId;
        Name = name;
        OwnerName = ownerName;
    }

    public MountInformationsForPaddock()
    {
    }

    public virtual short TypeId => Id;

    public ushort ModelId { get; set; }

    public string Name { get; set; }

    public string OwnerName { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ModelId);
        writer.WriteUTF(Name);
        writer.WriteUTF(OwnerName);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ModelId = reader.ReadVarUShort();
        Name = reader.ReadUTF();
        OwnerName = reader.ReadUTF();
    }
}