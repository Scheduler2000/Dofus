using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class MapCoordinatesAndId : MapCoordinates
{
    public new const short Id = 1741;

    public MapCoordinatesAndId(short worldX, short worldY, double mapId)
    {
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
    }

    public MapCoordinatesAndId()
    {
    }

    public override short TypeId => Id;

    public double MapId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteDouble(MapId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        MapId = reader.ReadDouble();
    }
}