using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class MapCoordinates
{
    public const short Id = 3568;

    public MapCoordinates(short worldX, short worldY)
    {
        WorldX = worldX;
        WorldY = worldY;
    }

    public MapCoordinates()
    {
    }

    public virtual short TypeId => Id;

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
    }
}