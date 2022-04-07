using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachEnterMessage : Message
{
    public const uint Id = 6485;

    public BreachEnterMessage(ulong owner)
    {
        Owner = owner;
    }

    public BreachEnterMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Owner { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(Owner);
    }

    public override void Deserialize(IDataReader reader)
    {
        Owner = reader.ReadVarULong();
    }
}