using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HavenBagFurnitureInformation
{
    public const short Id = 3647;

    public HavenBagFurnitureInformation(ushort cellId, int funitureId, sbyte orientation)
    {
        CellId = cellId;
        FunitureId = funitureId;
        Orientation = orientation;
    }

    public HavenBagFurnitureInformation()
    {
    }

    public virtual short TypeId => Id;

    public ushort CellId { get; set; }

    public int FunitureId { get; set; }

    public sbyte Orientation { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(CellId);
        writer.WriteInt(FunitureId);
        writer.WriteSByte(Orientation);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        CellId = reader.ReadVarUShort();
        FunitureId = reader.ReadInt();
        Orientation = reader.ReadSByte();
    }
}