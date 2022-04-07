using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHouseSearchMessage : Message
{
    public const uint Id = 6250;

    public ExchangeBidHouseSearchMessage(ushort genId, bool follow)
    {
        GenId = genId;
        Follow = follow;
    }

    public ExchangeBidHouseSearchMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort GenId { get; set; }

    public bool Follow { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(GenId);
        writer.WriteBoolean(Follow);
    }

    public override void Deserialize(IDataReader reader)
    {
        GenId = reader.ReadVarUShort();
        Follow = reader.ReadBoolean();
    }
}