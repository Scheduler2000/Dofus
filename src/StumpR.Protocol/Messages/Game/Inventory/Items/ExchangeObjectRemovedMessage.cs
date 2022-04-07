using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectRemovedMessage : ExchangeObjectMessage
{
    public new const uint Id = 7006;

    public ExchangeObjectRemovedMessage(bool remote, uint objectUID)
    {
        Remote = remote;
        ObjectUID = objectUID;
    }

    public ExchangeObjectRemovedMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ObjectUID { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(ObjectUID);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ObjectUID = reader.ReadVarUInt();
    }
}