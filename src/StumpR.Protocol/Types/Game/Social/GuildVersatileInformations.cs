using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GuildVersatileInformations
{
    public const short Id = 4170;

    public GuildVersatileInformations(uint guildId, ulong leaderId, byte guildLevel, byte nbMembers)
    {
        GuildId = guildId;
        LeaderId = leaderId;
        GuildLevel = guildLevel;
        NbMembers = nbMembers;
    }

    public GuildVersatileInformations()
    {
    }

    public virtual short TypeId => Id;

    public uint GuildId { get; set; }

    public ulong LeaderId { get; set; }

    public byte GuildLevel { get; set; }

    public byte NbMembers { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(GuildId);
        writer.WriteVarULong(LeaderId);
        writer.WriteByte(GuildLevel);
        writer.WriteByte(NbMembers);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        GuildId = reader.ReadVarUInt();
        LeaderId = reader.ReadVarULong();
        GuildLevel = reader.ReadByte();
        NbMembers = reader.ReadByte();
    }
}