using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ActorOrientation
{
    public const short Id = 6459;

    public ActorOrientation(double objectId, sbyte direction)
    {
        ObjectId = objectId;
        Direction = direction;
    }

    public ActorOrientation()
    {
    }

    public virtual short TypeId => Id;

    public double ObjectId { get; set; }

    public sbyte Direction { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(ObjectId);
        writer.WriteSByte(Direction);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadDouble();
        Direction = reader.ReadSByte();
    }
}