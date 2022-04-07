using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildChangeMemberParametersMessage : Message
{
    public const uint Id = 3633;

    public GuildChangeMemberParametersMessage(ulong memberId, ushort rank, sbyte experienceGivenPercent, uint rights)
    {
        MemberId = memberId;
        Rank = rank;
        ExperienceGivenPercent = experienceGivenPercent;
        Rights = rights;
    }

    public GuildChangeMemberParametersMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong MemberId { get; set; }

    public ushort Rank { get; set; }

    public sbyte ExperienceGivenPercent { get; set; }

    public uint Rights { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(MemberId);
        writer.WriteVarUShort(Rank);
        writer.WriteSByte(ExperienceGivenPercent);
        writer.WriteVarUInt(Rights);
    }

    public override void Deserialize(IDataReader reader)
    {
        MemberId = reader.ReadVarULong();
        Rank = reader.ReadVarUShort();
        ExperienceGivenPercent = reader.ReadSByte();
        Rights = reader.ReadVarUInt();
    }
}