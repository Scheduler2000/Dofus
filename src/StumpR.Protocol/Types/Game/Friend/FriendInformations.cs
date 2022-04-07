using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FriendInformations : AbstractContactInformations
{
    public new const short Id = 8035;

    public FriendInformations(int accountId,
        AccountTagInformation accountTag,
        sbyte playerState,
        ushort lastConnection,
        int achievementPoints,
        short leagueId,
        int ladderPosition)
    {
        AccountId = accountId;
        AccountTag = accountTag;
        PlayerState = playerState;
        LastConnection = lastConnection;
        AchievementPoints = achievementPoints;
        LeagueId = leagueId;
        LadderPosition = ladderPosition;
    }

    public FriendInformations()
    {
    }

    public override short TypeId => Id;

    public sbyte PlayerState { get; set; }

    public ushort LastConnection { get; set; }

    public int AchievementPoints { get; set; }

    public short LeagueId { get; set; }

    public int LadderPosition { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(PlayerState);
        writer.WriteVarUShort(LastConnection);
        writer.WriteInt(AchievementPoints);
        writer.WriteVarShort(LeagueId);
        writer.WriteInt(LadderPosition);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerState = reader.ReadSByte();
        LastConnection = reader.ReadVarUShort();
        AchievementPoints = reader.ReadInt();
        LeagueId = reader.ReadVarShort();
        LadderPosition = reader.ReadInt();
    }
}