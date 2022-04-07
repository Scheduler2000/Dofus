using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FriendOnlineInformations : FriendInformations
{
    public new const short Id = 3896;

    public FriendOnlineInformations(int accountId,
        AccountTagInformation accountTag,
        sbyte playerState,
        ushort lastConnection,
        int achievementPoints,
        short leagueId,
        int ladderPosition,
        bool sex,
        bool havenBagShared,
        ulong playerId,
        string playerName,
        ushort level,
        sbyte alignmentSide,
        sbyte breed,
        GuildInformations guildInfo,
        ushort moodSmileyId,
        PlayerStatus status)
    {
        AccountId = accountId;
        AccountTag = accountTag;
        PlayerState = playerState;
        LastConnection = lastConnection;
        AchievementPoints = achievementPoints;
        LeagueId = leagueId;
        LadderPosition = ladderPosition;
        Sex = sex;
        HavenBagShared = havenBagShared;
        PlayerId = playerId;
        PlayerName = playerName;
        Level = level;
        AlignmentSide = alignmentSide;
        Breed = breed;
        GuildInfo = guildInfo;
        MoodSmileyId = moodSmileyId;
        Status = status;
    }

    public FriendOnlineInformations()
    {
    }

    public override short TypeId => Id;

    public bool Sex { get; set; }

    public bool HavenBagShared { get; set; }

    public ulong PlayerId { get; set; }

    public string PlayerName { get; set; }

    public ushort Level { get; set; }

    public sbyte AlignmentSide { get; set; }

    public sbyte Breed { get; set; }

    public GuildInformations GuildInfo { get; set; }

    public ushort MoodSmileyId { get; set; }

    public PlayerStatus Status { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, Sex);
        flag = BooleanByteWrapper.SetFlag(flag, 1, HavenBagShared);
        writer.WriteByte(flag);
        writer.WriteVarULong(PlayerId);
        writer.WriteUTF(PlayerName);
        writer.WriteVarUShort(Level);
        writer.WriteSByte(AlignmentSide);
        writer.WriteSByte(Breed);
        GuildInfo.Serialize(writer);
        writer.WriteVarUShort(MoodSmileyId);
        writer.WriteShort(Status.TypeId);
        Status.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        byte flag = reader.ReadByte();
        Sex = BooleanByteWrapper.GetFlag(flag, 0);
        HavenBagShared = BooleanByteWrapper.GetFlag(flag, 1);
        PlayerId = reader.ReadVarULong();
        PlayerName = reader.ReadUTF();
        Level = reader.ReadVarUShort();
        AlignmentSide = reader.ReadSByte();
        Breed = reader.ReadSByte();
        GuildInfo = new GuildInformations();
        GuildInfo.Deserialize(reader);
        MoodSmileyId = reader.ReadVarUShort();
        Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
        Status.Deserialize(reader);
    }
}