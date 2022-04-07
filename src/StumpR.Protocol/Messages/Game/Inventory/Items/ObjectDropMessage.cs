using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectDropMessage : Message
{
    public const uint Id = 5971;

    public ObjectDropMessage(uint objectUID, uint quantity)
    {
        ObjectUID = objectUID;
        Quantity = quantity;
    }

    public ObjectDropMessage()
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