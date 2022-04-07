using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class EntityDispositionInformations
{
    public const short Id = 7424;

    public EntityDispositionInformations(short cellId, sbyte direction)
    {
        CellId = cellId;
        Direction = direction;
    }

    public EntityDispositionInformations()
    {
    }

    public virtual short TypeId => Id;

    public short CellId { get; set; }

    public sbyte Direction { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort(CellId);
        writer.WriteSByte(Direction);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        CellId = reader.ReadShort();
        Direction = reader.ReadSByte();
    }
}