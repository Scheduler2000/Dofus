using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class EntityMovementInformations
{
    public const short Id = 7283;

    public EntityMovementInformations(int objectId, IEnumerable<sbyte> steps)
    {
        ObjectId = objectId;
        Steps = steps;
    }

    public EntityMovementInformations()
    {
    }

    public virtual short TypeId => Id;

    public int ObjectId { get; set; }

    public IEnumerable<sbyte> Steps { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(ObjectId);
        writer.WriteShort((short) Steps.Count());
        foreach (sbyte objectToSend in Steps) writer.WriteSByte(objectToSend);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadInt();
        ushort stepsCount = reader.ReadUShort();
        var steps_ = new sbyte[stepsCount];
        for (var stepsIndex = 0; stepsIndex < stepsCount; stepsIndex++) steps_[stepsIndex] = reader.ReadSByte();
        Steps = steps_;
    }
}