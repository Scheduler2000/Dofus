using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AtlasPointsInformations
{
    public const short Id = 4410;

    public AtlasPointsInformations(sbyte type, IEnumerable<MapCoordinatesExtended> coords)
    {
        Type = type;
        Coords = coords;
    }

    public AtlasPointsInformations()
    {
    }

    public virtual short TypeId => Id;

    public sbyte Type { get; set; }

    public IEnumerable<MapCoordinatesExtended> Coords { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Type);
        writer.WriteShort((short) Coords.Count());
        foreach (MapCoordinatesExtended objectToSend in Coords) objectToSend.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        Type = reader.ReadSByte();
        ushort coordsCount = reader.ReadUShort();
        var coords_ = new MapCoordinatesExtended[coordsCount];

        for (var coordsIndex = 0; coordsIndex < coordsCount; coordsIndex++)
        {
            var objectToAdd = new MapCoordinatesExtended();
            objectToAdd.Deserialize(reader);
            coords_[coordsIndex] = objectToAdd;
        }
        Coords = coords_;
    }
}