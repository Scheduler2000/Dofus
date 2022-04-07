using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class IgnoredOnlineInformations : IgnoredInformations
{
    public new const short Id = 7223;

    public IgnoredOnlineInformations(int accountId,
        AccountTagInformation accountTag,
        ulong playerId,
        string playerName,
        sbyte breed,
        bool sex)
    {
        AccountId = accountId;
        AccountTag = accountTag;
        PlayerId = playerId;
        PlayerName = playerName;
        Breed = breed;
        Sex = sex;
    }

    public IgnoredOnlineInformations()
    {
    }

    public override short TypeId => Id;

    public ulong PlayerId { get; set; }

    public string PlayerName { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(PlayerId);
        writer.WriteUTF(PlayerName);
        writer.WriteSByte(Breed);
        writer.WriteBoolean(Sex);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerId = reader.ReadVarULong();
        PlayerName = reader.ReadUTF();
        Breed = reader.ReadSByte();
        Sex = reader.ReadBoolean();
    }
}