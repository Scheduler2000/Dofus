using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DebtsUpdateMessage : Message
{
    public const uint Id = 2524;

    public DebtsUpdateMessage(sbyte action, IEnumerable<DebtInformation> debts)
    {
        Action = action;
        Debts = debts;
    }

    public DebtsUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Action { get; set; }

    public IEnumerable<DebtInformation> Debts { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Action);
        writer.WriteShort((short) Debts.Count());

        foreach (DebtInformation objectToSend in Debts)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        Action = reader.ReadSByte();
        ushort debtsCount = reader.ReadUShort();
        var debts_ = new DebtInformation[debtsCount];

        for (var debtsIndex = 0; debtsIndex < debtsCount; debtsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<DebtInformation>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            debts_[debtsIndex] = objectToAdd;
        }
        Debts = debts_;
    }
}