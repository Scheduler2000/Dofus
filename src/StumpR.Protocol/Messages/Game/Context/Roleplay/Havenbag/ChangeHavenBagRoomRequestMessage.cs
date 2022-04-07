using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChangeHavenBagRoomRequestMessage : Message
{
    public const uint Id = 7038;

    public ChangeHavenBagRoomRequestMessage(sbyte roomId)
    {
        RoomId = roomId;
    }

    public ChangeHavenBagRoomRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte RoomId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(RoomId);
    }

    public override void Deserialize(IDataReader reader)
    {
        RoomId = reader.ReadSByte();
    }
}