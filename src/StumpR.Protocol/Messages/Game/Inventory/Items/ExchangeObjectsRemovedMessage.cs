using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectsRemovedMessage : ExchangeObjectMessage
{
    public new const uint Id = 4841;

    public ExchangeObjectsRemovedMessage(bool remote, IEnumerable<uint> objectUID)
    {
        Remote = remote;
        ObjectUID = objectUID;
    }

    public ExchangeObjectsRemovedMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<uint> ObjectUID { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) ObjectUID.Count());
        foreach (uint objectToSend in ObjectUID) writer.WriteVarUInt(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort objectUIDCount = reader.ReadUShort();
        var objectUID_ = new uint[objectUIDCount];
        for (var objectUIDIndex = 0; objectUIDIndex < objectUIDCount; objectUIDIndex++) objectUID_[objectUIDIndex] = reader.ReadVarUInt();
        ObjectUID = objectUID_;
    }
}