using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectModifiedMessage : Message
{
    public const uint Id = 2793;

    public ObjectModifiedMessage(ObjectItem @object)
    {
        this.@object = @object;
    }

    public ObjectModifiedMessage()
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