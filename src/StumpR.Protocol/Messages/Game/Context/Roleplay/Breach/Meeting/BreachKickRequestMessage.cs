using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachKickRequestMessage : Message
{
    public const uint Id = 2909;

    public BreachKickRequestMessage(ulong target)
    {
        Target = target;
    }

    public BreachKickRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Target { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(Target);
    }

    public override void Deserialize(IDataReader reader)
    {
        Target = reader.ReadVarULong();
    }
}