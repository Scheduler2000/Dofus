using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachRoomUnlockRequestMessage : Message
{
    public const uint Id = 8276;

    public BreachRoomUnlockRequestMessage(sbyte roomId)
    {
        RoomId = roomId;
    }

    public BreachRoomUnlockRequestMessage()
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