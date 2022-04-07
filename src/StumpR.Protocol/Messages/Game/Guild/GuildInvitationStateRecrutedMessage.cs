using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildInvitationStateRecrutedMessage : Message
{
    public const uint Id = 621;

    public GuildInvitationStateRecrutedMessage(sbyte invitationState)
    {
        InvitationState = invitationState;
    }

    public GuildInvitationStateRecrutedMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte InvitationState { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(InvitationState);
    }

    public override void Deserialize(IDataReader reader)
    {
        InvitationState = reader.ReadSByte();
    }
}