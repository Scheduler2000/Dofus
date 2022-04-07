using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceInvitedMessage : Message
{
    public const uint Id = 6009;

    public AllianceInvitedMessage(ulong recruterId, string recruterName, BasicNamedAllianceInformations allianceInfo)
    {
        RecruterId = recruterId;
        RecruterName = recruterName;
        AllianceInfo = allianceInfo;
    }

    public AllianceInvitedMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong RecruterId { get; set; }

    public string RecruterName { get; set; }

    public BasicNamedAllianceInformations AllianceInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(RecruterId);
        writer.WriteUTF(RecruterName);
        AllianceInfo.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        RecruterId = reader.ReadVarULong();
        RecruterName = reader.ReadUTF();
        AllianceInfo = new BasicNamedAllianceInformations();
        AllianceInfo.Deserialize(reader);
    }
}