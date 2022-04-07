using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectSetPositionMessage : Message
{
    public const uint Id = 5107;

    public ObjectSetPositionMessage(uint objectUID, short position, uint quantity)
    {
        ObjectUID = objectUID;
        Position = position;
        Quantity = quantity;
    }

    public ObjectSetPositionMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ObjectUID { get; set; }

    public short Position { get; set; }

    public uint Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectUID);
        writer.WriteShort(Position);
        writer.WriteVarUInt(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectUID = reader.ReadVarUInt();
        Position = reader.ReadShort();
        Quantity = reader.ReadVarUInt();
    }
}