using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceListMessage : Message
{
    public const uint Id = 3861;

    public AllianceListMessage(IEnumerable<AllianceFactSheetInformations> alliances)
    {
        Alliances = alliances;
    }

    public AllianceListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<AllianceFactSheetInformations> Alliances { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Alliances.Count());
        foreach (AllianceFactSheetInformations objectToSend in Alliances) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort alliancesCount = reader.ReadUShort();
        var alliances_ = new AllianceFactSheetInformations[alliancesCount];

        for (var alliancesIndex = 0; alliancesIndex < alliancesCount; alliancesIndex++)
        {
            var objectToAdd = new AllianceFactSheetInformations();
            objectToAdd.Deserialize(reader);
            alliances_[alliancesIndex] = objectToAdd;
        }
        Alliances = alliances_;
    }
}