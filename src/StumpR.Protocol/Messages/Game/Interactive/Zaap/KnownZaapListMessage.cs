using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class KnownZaapListMessage : Message
{
    public const uint Id = 4096;

    public KnownZaapListMessage(IEnumerable<double> destinations)
    {
        Destinations = destinations;
    }

    public KnownZaapListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<double> Destinations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Destinations.Count());
        foreach (double objectToSend in Destinations) writer.WriteDouble(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort destinationsCount = reader.ReadUShort();
        var destinations_ = new double[destinationsCount];

        for (var destinationsIndex = 0; destinationsIndex < destinationsCount; destinationsIndex++)
            destinations_[destinationsIndex] = reader.ReadDouble();
        Destinations = destinations_;
    }
}