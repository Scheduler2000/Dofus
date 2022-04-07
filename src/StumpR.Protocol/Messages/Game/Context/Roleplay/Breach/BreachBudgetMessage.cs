using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachBudgetMessage : Message
{
    public const uint Id = 1903;

    public BreachBudgetMessage(uint bugdet)
    {
        Bugdet = bugdet;
    }

    public BreachBudgetMessage()
    {
    }

    public override uint MessageId => Id;

    public uint Bugdet { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(Bugdet);
    }

    public override void Deserialize(IDataReader reader)
    {
        Bugdet = reader.ReadVarUInt();
    }
}