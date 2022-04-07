using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StorageObjectRemoveMessage : Message
{
    public const uint Id = 4970;

    public StorageObjectRemoveMessage(uint objectUID)
    {
        ObjectUID = objectUID;
    }

    public StorageObjectRemoveMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ObjectUID { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectUID);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectUID = reader.ReadVarUInt();
    }
}