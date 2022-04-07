using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeOkMultiCraftMessage : Message
{
    public const uint Id = 2595;

    public ExchangeOkMultiCraftMessage(ulong initiatorId, ulong otherId, sbyte role)
    {
        InitiatorId = initiatorId;
        OtherId = otherId;
        Role = role;
    }

    public ExchangeOkMultiCraftMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong InitiatorId { get; set; }

    public ulong OtherId { get; set; }

    public sbyte Role { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(InitiatorId);
        writer.WriteVarULong(OtherId);
        writer.WriteSByte(Role);
    }

    public override void Deserialize(IDataReader reader)
    {
        InitiatorId = reader.ReadVarULong();
        OtherId = reader.ReadVarULong();
        Role = reader.ReadSByte();
    }
}