using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeObjectModifiedInBagMessage : ExchangeObjectMessage
{
    public new const uint Id = 1456;

    public ExchangeObjectModifiedInBagMessage(bool remote, ObjectItem @object)
    {
        Remote = remote;
        this.@object = @object;
    }

    public ExchangeObjectModifiedInBagMessage()
    {
    }

    public override uint MessageId => Id;

    public ObjectItem @object { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        @object.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        @object = new ObjectItem();
        @object.Deserialize(reader);
    }
}