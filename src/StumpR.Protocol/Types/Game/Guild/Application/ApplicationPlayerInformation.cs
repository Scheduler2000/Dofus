using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ApplicationPlayerInformation
{
    public const short Id = 3872;

    public ApplicationPlayerInformation(uint playerId,
        string playerName,
        sbyte breed,
        bool sex,
        uint level,
        uint accountId,
        string accountTag,
        string accountNickname,
        PlayerStatus status)
    {
        PlayerId = playerId;
        PlayerName = playerName;
        Breed = breed;
        Sex = sex;
        Level = level;
        AccountId = accountId;
        AccountTag = accountTag;
        AccountNickname = accountNickname;
        Status = status;
    }

    public ApplicationPlayerInformation()
    {
    }

    public virtual short TypeId => Id;

    public uint PlayerId { get; set; }

    public string PlayerName { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public uint Level { get; set; }

    public uint AccountId { get; set; }

    public string AccountTag { get; set; }

    public string AccountNickname { get; set; }

    public PlayerStatus Status { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(PlayerId);
        writer.WriteUTF(PlayerName);
        writer.WriteSByte(Breed);
        writer.WriteBoolean(Sex);
        writer.WriteVarUInt(Level);
        writer.WriteVarUInt(AccountId);
        writer.WriteUTF(AccountTag);
        writer.WriteUTF(AccountNickname);
        Status.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        PlayerId = reader.ReadVarUInt();
        PlayerName = reader.ReadUTF();
        Breed = reader.ReadSByte();
        Sex = reader.ReadBoolean();
        Level = reader.ReadVarUInt();
        AccountId = reader.ReadVarUInt();
        AccountTag = reader.ReadUTF();
        AccountNickname = reader.ReadUTF();
        Status = new PlayerStatus();
        Status.Deserialize(reader);
    }
}