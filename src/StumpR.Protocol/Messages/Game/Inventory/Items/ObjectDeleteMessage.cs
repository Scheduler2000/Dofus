using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectDeleteMessage : Message
{
    public const uint Id = 8147;

    public ObjectDeleteMessage(uint objectUID, uint quantity)
    {
        ObjectUID = objectUID;
        Quantity = quantity;
    }

    public ObjectDeleteMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ObjectUID { get; set; }

    public uint Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectUID);
        writer.WriteVarUInt(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectUID = reader.ReadVarUInt();
        Quantity = reader.ReadVarUInt();
    }
}