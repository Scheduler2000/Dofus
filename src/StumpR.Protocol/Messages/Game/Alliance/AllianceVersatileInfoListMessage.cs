using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceVersatileInfoListMessage : Message
{
    public const uint Id = 9853;

    public AllianceVersatileInfoListMessage(IEnumerable<AllianceVersatileInformations> alliances)
    {
        Alliances = alliances;
    }

    public AllianceVersatileInfoListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<AllianceVersatileInformations> Alliances { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Alliances.Count());
        foreach (AllianceVersatileInformations objectToSend in Alliances) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort alliancesCount = reader.ReadUShort();
        var alliances_ = new AllianceVersatileInformations[alliancesCount];

        for (var alliancesIndex = 0; alliancesIndex < alliancesCount; alliancesIndex++)
        {
            var objectToAdd = new AllianceVersatileInformations();
            objectToAdd.Deserialize(reader);
            alliances_[alliancesIndex] = objectToAdd;
        }
        Alliances = alliances_;
    }
}