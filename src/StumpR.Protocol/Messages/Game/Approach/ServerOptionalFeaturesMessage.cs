using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ServerOptionalFeaturesMessage : Message
{
    public const uint Id = 189;

    public ServerOptionalFeaturesMessage(IEnumerable<byte> features)
    {
        Features = features;
    }

    public ServerOptionalFeaturesMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<byte> Features { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Features.Count());
        foreach (byte objectToSend in Features) writer.WriteByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort featuresCount = reader.ReadUShort();
        var features_ = new byte[featuresCount];
        for (var featuresIndex = 0; featuresIndex < featuresCount; featuresIndex++) features_[featuresIndex] = reader.ReadByte();
        Features = features_;
    }
}