using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StorageObjectUpdateMessage : Message
{
    public const uint Id = 728;

    public StorageObjectUpdateMessage(ObjectItem @object)
    {
        this.@object = @object;
    }

    public StorageObjectUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public ObjectItem @object { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        @object.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        @object = new ObjectItem();
        @object.Deserialize(reader);
    }
}