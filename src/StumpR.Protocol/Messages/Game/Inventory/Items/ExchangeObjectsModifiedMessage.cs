using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectsModifiedMessage : ExchangeObjectMessage
{
    public new const uint Id = 145;

    public ExchangeObjectsModifiedMessage(bool remote, IEnumerable<ObjectItem> @object)
    {
        Remote = remote;
        this.@object = @object;
    }

    public ExchangeObjectsModifiedMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ObjectItem> @object { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) @object.Count());
        foreach (ObjectItem objectToSend in @object) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort objectCount = reader.ReadUShort();
        var object_ = new ObjectItem[objectCount];

        for (var objectIndex = 0; objectIndex < objectCount; objectIndex++)
        {
            var objectToAdd = new ObjectItem();
            objectToAdd.Deserialize(reader);
            object_[objectIndex] = objectToAdd;
        }
        @object = object_;
    }
}