using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectUseMessage : Message
{
    public const uint Id = 3065;

    public ObjectUseMessage(uint objectUID)
    {
        ObjectUID = objectUID;
    }

    public ObjectUseMessage()
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