using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DebtsDeleteMessage : Message
{
    public const uint Id = 5619;

    public DebtsDeleteMessage(sbyte reason, IEnumerable<double> debts)
    {
        Reason = reason;
        Debts = debts;
    }

    public DebtsDeleteMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Reason { get; set; }

    public IEnumerable<double> Debts { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Reason);
        writer.WriteShort((short) Debts.Count());
        foreach (double objectToSend in Debts) writer.WriteDouble(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        Reason = reader.ReadSByte();
        ushort debtsCount = reader.ReadUShort();
        var debts_ = new double[debtsCount];
        for (var debtsIndex = 0; debtsIndex < debtsCount; debtsIndex++) debts_[debtsIndex] = reader.ReadDouble();
        Debts = debts_;
    }
}