using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildMemberLeavingMessage : Message
{
    public const uint Id = 419;

    public GuildMemberLeavingMessage(bool kicked, ulong memberId)
    {
        Kicked = kicked;
        MemberId = memberId;
    }

    public GuildMemberLeavingMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Kicked { get; set; }

    public ulong MemberId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Kicked);
        writer.WriteVarULong(MemberId);
    }

    public override void Deserialize(IDataReader reader)
    {
        Kicked = reader.ReadBoolean();
        MemberId = reader.ReadVarULong();
    }
}