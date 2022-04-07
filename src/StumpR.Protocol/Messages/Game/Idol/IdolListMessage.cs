using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class IdolListMessage : Message
{
    public const uint Id = 9410;

    public IdolListMessage(IEnumerable<ushort> chosenIdols, IEnumerable<ushort> partyChosenIdols, IEnumerable<PartyIdol> partyIdols)
    {
        ChosenIdols = chosenIdols;
        PartyChosenIdols = partyChosenIdols;
        PartyIdols = partyIdols;
    }

    public IdolListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ushort> ChosenIdols { get; set; }

    public IEnumerable<ushort> PartyChosenIdols { get; set; }

    public IEnumerable<PartyIdol> PartyIdols { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) ChosenIdols.Count());
        foreach (ushort objectToSend in ChosenIdols) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) PartyChosenIdols.Count());
        foreach (ushort objectToSend in PartyChosenIdols) writer.WriteVarUShort(objectToSend);
        writer.WriteShort((short) PartyIdols.Count());

        foreach (PartyIdol objectToSend in PartyIdols)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort chosenIdolsCount = reader.ReadUShort();
        var chosenIdols_ = new ushort[chosenIdolsCount];

        for (var chosenIdolsIndex = 0; chosenIdolsIndex < chosenIdolsCount; chosenIdolsIndex++)
            chosenIdols_[chosenIdolsIndex] = reader.ReadVarUShort();
        ChosenIdols = chosenIdols_;
        ushort partyChosenIdolsCount = reader.ReadUShort();
        var partyChosenIdols_ = new ushort[partyChosenIdolsCount];

        for (var partyChosenIdolsIndex = 0; partyChosenIdolsIndex < partyChosenIdolsCount; partyChosenIdolsIndex++)
            partyChosenIdols_[partyChosenIdolsIndex] = reader.ReadVarUShort();
        PartyChosenIdols = partyChosenIdols_;
        ushort partyIdolsCount = reader.ReadUShort();
        var partyIdols_ = new PartyIdol[partyIdolsCount];

        for (var partyIdolsIndex = 0; partyIdolsIndex < partyIdolsCount; partyIdolsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<PartyIdol>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            partyIdols_[partyIdolsIndex] = objectToAdd;
        }
        PartyIdols = partyIdols_;
    }
}