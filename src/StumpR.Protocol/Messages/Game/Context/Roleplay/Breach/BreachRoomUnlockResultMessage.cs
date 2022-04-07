using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachRoomUnlockResultMessage : Message
{
    public const uint Id = 3212;

    public BreachRoomUnlockResultMessage(sbyte roomId, sbyte result)
    {
        RoomId = roomId;
        Result = result;
    }

    public BreachRoomUnlockResultMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte RoomId { get; set; }

    public sbyte Result { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(RoomId);
        writer.WriteSByte(Result);
    }

    public override void Deserialize(IDataReader reader)
    {
        RoomId = reader.ReadSByte();
        Result = reader.ReadSByte();
    }
}