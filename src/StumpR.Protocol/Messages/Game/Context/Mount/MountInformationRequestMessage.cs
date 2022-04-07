using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountInformationRequestMessage : Message
{
    public const uint Id = 2112;

    public MountInformationRequestMessage(double objectId, double time)
    {
        ObjectId = objectId;
        Time = time;
    }

    public MountInformationRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public double ObjectId { get; set; }

    public double Time { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(ObjectId);
        writer.WriteDouble(Time);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadDouble();
        Time = reader.ReadDouble();
    }
}