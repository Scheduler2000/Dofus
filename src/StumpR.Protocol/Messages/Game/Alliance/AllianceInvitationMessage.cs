using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceInvitationMessage : Message
{
    public const uint Id = 235;

    public AllianceInvitationMessage(ulong targetId)
    {
        TargetId = targetId;
    }

    public AllianceInvitationMessage()
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