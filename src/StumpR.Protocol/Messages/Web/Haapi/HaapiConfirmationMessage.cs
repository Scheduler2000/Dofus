using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HaapiConfirmationMessage : Message
{
    public const uint Id = 5733;

    public HaapiConfirmationMessage(ulong kamas, ulong amount, ushort rate, sbyte action, string transaction)
    {
        Kamas = kamas;
        Amount = amount;
        Rate = rate;
        Action = action;
        Transaction = transaction;
    }

    public HaapiConfirmationMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong Kamas { get; set; }

    public ulong Amount { get; set; }

    public ushort Rate { get; set; }

    public sbyte Action { get; set; }

    public string Transaction { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(Kamas);
        writer.WriteVarULong(Amount);
        writer.WriteVarUShort(Rate);
        writer.WriteSByte(Action);
        writer.WriteUTF(Transaction);
    }

    public override void Deserialize(IDataReader reader)
    {
        Kamas = reader.ReadVarULong();
        Amount = reader.ReadVarULong();
        Rate = reader.ReadVarUShort();
        Action = reader.ReadSByte();
        Transaction = reader.ReadUTF();
    }
}