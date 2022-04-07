using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectUseMultipleMessage : ObjectUseMessage
{
    public new const uint Id = 1126;

    public ObjectUseMultipleMessage(uint objectUID, uint quantity)
    {
        ObjectUID = objectUID;
        Quantity = quantity;
    }

    public ObjectUseMultipleMessage()
    {
    }

    public override uint MessageId => Id;

    public uint Quantity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(Quantity);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Quantity = reader.ReadVarUInt();
    }
}