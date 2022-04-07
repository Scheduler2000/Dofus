using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildInvitationMessage : Message
{
    public const uint Id = 2715;

    public GuildInvitationMessage(ulong targetId)
    {
        TargetId = targetId;
    }

    public GuildInvitationMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong TargetId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(TargetId);
    }

    public override void Deserialize(IDataReader reader)
    {
        TargetId = reader.ReadVarULong();
    }
}