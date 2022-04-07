using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangePodsModifiedMessage : ExchangeObjectMessage
{
    public new const uint Id = 7130;

    public ExchangePodsModifiedMessage(bool remote, uint currentWeight, uint maxWeight)
    {
        Remote = remote;
        CurrentWeight = currentWeight;
        MaxWeight = maxWeight;
    }

    public ExchangePodsModifiedMessage()
    {
    }

    public override uint MessageId => Id;

    public uint CurrentWeight { get; set; }

    public uint MaxWeight { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(CurrentWeight);
        writer.WriteVarUInt(MaxWeight);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        CurrentWeight = reader.ReadVarUInt();
        MaxWeight = reader.ReadVarUInt();
    }
}