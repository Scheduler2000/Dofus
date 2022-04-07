using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class BasicGuildInformations : AbstractSocialGroupInfos
{
    public new const short Id = 4374;

    public BasicGuildInformations(uint guildId, string guildName, byte guildLevel)
    {
        GuildId = guildId;
        GuildName = guildName;
        GuildLevel = guildLevel;
    }

    public BasicGuildInformations()
    {
    }

    public override short TypeId => Id;

    public uint GuildId { get; set; }

    public string GuildName { get; set; }

    public byte GuildLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(GuildId);
        writer.WriteUTF(GuildName);
        writer.WriteByte(GuildLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        GuildId = reader.ReadVarUInt();
        GuildName = reader.ReadUTF();
        GuildLevel = reader.ReadByte();
    }
}