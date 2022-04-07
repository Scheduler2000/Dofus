using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TreasureHuntFlag
{
    public const short Id = 4191;

    public TreasureHuntFlag(double mapId, sbyte state)
    {
        MapId = mapId;
        State = state;
    }

    public TreasureHuntFlag()
    {
    }

    public virtual short TypeId => Id;

    public double MapId { get; set; }

    public sbyte State { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(MapId);
        writer.WriteSByte(State);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        MapId = reader.ReadDouble();
        State = reader.ReadSByte();
    }
}