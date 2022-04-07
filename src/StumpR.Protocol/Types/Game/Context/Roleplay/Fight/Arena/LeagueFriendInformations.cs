using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class LeagueFriendInformations : AbstractContactInformations
{
    public new const short Id = 107;

    public LeagueFriendInformations(int accountId,
        AccountTagInformation accountTag,
        ulong playerId,
        string playerName,
        sbyte breed,
        bool sex,
        ushort level,
        short leagueId,
        short totalLeaguePoints,
        int ladderPosition)
    {
        AccountId = accountId;
        AccountTag = accountTag;
        PlayerId = playerId;
        PlayerName = playerName;
        Breed = breed;
        Sex = sex;
        Level = level;
        LeagueId = leagueId;
        TotalLeaguePoints = totalLeaguePoints;
        LadderPosition = ladderPosition;
    }

    public LeagueFriendInformations()
    {
    }

    public override short TypeId => Id;

    public ulong PlayerId { get; set; }

    public string PlayerName { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public ushort Level { get; set; }

    public short LeagueId { get; set; }

    public short TotalLeaguePoints { get; set; }

    public int LadderPosition { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(PlayerId);
        writer.WriteUTF(PlayerName);
        writer.WriteSByte(Breed);
        writer.WriteBoolean(Sex);
        writer.WriteVarUShort(Level);
        writer.WriteVarShort(LeagueId);
        writer.WriteVarShort(TotalLeaguePoints);
        writer.WriteInt(LadderPosition);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerId = reader.ReadVarULong();
        PlayerName = reader.ReadUTF();
        Breed = reader.ReadSByte();
        Sex = reader.ReadBoolean();
        Level = reader.ReadVarUShort();
        LeagueId = reader.ReadVarShort();
        TotalLeaguePoints = reader.ReadVarShort();
        LadderPosition = reader.ReadInt();
    }
}