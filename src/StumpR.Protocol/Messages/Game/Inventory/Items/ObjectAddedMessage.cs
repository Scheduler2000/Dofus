using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectAddedMessage : Message
{
    public const uint Id = 9659;

    public ObjectAddedMessage(ObjectItem @object, sbyte origin)
    {
        this.@object = @object;
        Origin = origin;
    }

    public ObjectAddedMessage()
    {
    }

    public override uint MessageId => Id;

    public ObjectItem @object { get; set; }

    public sbyte Origin { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        @object.Serialize(writer);
        writer.WriteSByte(Origin);
    }

    public override void Deserialize(IDataReader reader)
    {
        @object = new ObjectItem();
        @object.Deserialize(reader);
        Origin = reader.ReadSByte();
    }
}