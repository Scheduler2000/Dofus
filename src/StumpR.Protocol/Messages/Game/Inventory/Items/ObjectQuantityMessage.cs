using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectQuantityMessage : Message
{
    public const uint Id = 80;

    public ObjectQuantityMessage(uint objectUID, uint quantity, sbyte origin)
    {
        ObjectUID = objectUID;
        Quantity = quantity;
        Origin = origin;
    }

    public ObjectQuantityMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ObjectUID { get; set; }

    public uint Quantity { get; set; }

    public sbyte Origin { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectUID);
        writer.WriteVarUInt(Quantity);
        writer.WriteSByte(Origin);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectUID = reader.ReadVarUInt();
        Quantity = reader.ReadVarUInt();
        Origin = reader.ReadSByte();
    }
}