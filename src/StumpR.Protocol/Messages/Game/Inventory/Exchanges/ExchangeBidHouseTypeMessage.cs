using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeBidHouseTypeMessage : Message
{
    public const uint Id = 4445;

    public ExchangeBidHouseTypeMessage(uint type, bool follow)
    {
        Type = type;
        Follow = follow;
    }

    public ExchangeBidHouseTypeMessage()
    {
    }

    public override uint MessageId => Id;

    public uint Type { get; set; }

    public bool Follow { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(Type);
        writer.WriteBoolean(Follow);
    }

    public override void Deserialize(IDataReader reader)
    {
        Type = reader.ReadVarUInt();
        Follow = reader.ReadBoolean();
    }
}