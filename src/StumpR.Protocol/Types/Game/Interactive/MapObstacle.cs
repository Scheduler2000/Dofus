using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class MapObstacle
{
    public const short Id = 5512;

    public MapObstacle(ushort obstacleCellId, sbyte state)
    {
        ObstacleCellId = obstacleCellId;
        State = state;
    }

    public MapObstacle()
    {
    }

    public virtual short TypeId => Id;

    public ushort ObstacleCellId { get; set; }

    public sbyte State { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObstacleCellId);
        writer.WriteSByte(State);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObstacleCellId = reader.ReadVarUShort();
        State = reader.ReadSByte();
    }
}