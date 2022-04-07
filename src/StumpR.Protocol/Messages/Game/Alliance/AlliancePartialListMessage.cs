using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AlliancePartialListMessage : AllianceListMessage
{
    public new const uint Id = 2592;

    public AlliancePartialListMessage(IEnumerable<AllianceFactSheetInformations> alliances)
    {
        Alliances = alliances;
    }

    public AlliancePartialListMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}