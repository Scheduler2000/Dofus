using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NumericWhoIsRequestMessage : Message
{
    public const uint Id = 4159;

    public NumericWhoIsRequestMessage(ulong playerId)
    {
        PlayerId = playerId;
    }

    public NumericWhoIsRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        PlayerId = reader.ReadVarULong();
    }
}