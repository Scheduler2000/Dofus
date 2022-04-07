using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TeleportDestinationsMessage : Message
{
    public const uint Id = 5651;

    public TeleportDestinationsMessage(sbyte type, IEnumerable<TeleportDestination> destinations)
    {
        Type = type;
        Destinations = destinations;
    }

    public TeleportDestinationsMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Type { get; set; }

    public IEnumerable<TeleportDestination> Destinations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Type);
        writer.WriteShort((short) Destinations.Count());
        foreach (TeleportDestination objectToSend in Destinations) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Type = reader.ReadSByte();
        ushort destinationsCount = reader.ReadUShort();
        var destinations_ = new TeleportDestination[destinationsCount];

        for (var destinationsIndex = 0; destinationsIndex < destinationsCount; destinationsIndex++)
        {
            var objectToAdd = new TeleportDestination();
            objectToAdd.Deserialize(reader);
            destinations_[destinationsIndex] = objectToAdd;
        }
        Destinations = destinations_;
    }
}