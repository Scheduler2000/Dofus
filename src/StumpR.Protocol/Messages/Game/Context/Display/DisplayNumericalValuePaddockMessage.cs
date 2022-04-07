using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DisplayNumericalValuePaddockMessage : Message
{
    public const uint Id = 5348;

    public DisplayNumericalValuePaddockMessage(int rideId, int value, sbyte type)
    {
        RideId = rideId;
        Value = value;
        Type = type;
    }

    public DisplayNumericalValuePaddockMessage()
    {
    }

    public override uint MessageId => Id;

    public int RideId { get; set; }

    public int Value { get; set; }

    public sbyte Type { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteInt(RideId);
        writer.WriteInt(Value);
        writer.WriteSByte(Type);
    }

    public override void Deserialize(IDataReader reader)
    {
        RideId = reader.ReadInt();
        Value = reader.ReadInt();
        Type = reader.ReadSByte();
    }
}