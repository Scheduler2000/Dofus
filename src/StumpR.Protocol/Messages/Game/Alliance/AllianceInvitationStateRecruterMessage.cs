using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceInvitationStateRecruterMessage : Message
{
    public const uint Id = 2498;

    public AllianceInvitationStateRecruterMessage(string recrutedName, sbyte invitationState)
    {
        RecrutedName = recrutedName;
        InvitationState = invitationState;
    }

    public AllianceInvitationStateRecruterMessage()
    {
    }

    public override uint MessageId => Id;

    public string RecrutedName { get; set; }

    public sbyte InvitationState { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(RecrutedName);
        writer.WriteSByte(InvitationState);
    }

    public override void Deserialize(IDataReader reader)
    {
        RecrutedName = reader.ReadUTF();
        InvitationState = reader.ReadSByte();
    }
}