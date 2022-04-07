using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MountInformationInPaddockRequestMessage : Message
{
    public const uint Id = 6636;

    public MountInformationInPaddockRequestMessage(int mapRideId)
    {
        MapRideId = mapRideId;
    }

    public MountInformationInPaddockRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public int MapRideId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarInt(MapRideId);
    }

    public override void Deserialize(IDataReader reader)
    {
        MapRideId = reader.ReadVarInt();
    }
}