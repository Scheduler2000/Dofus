using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class DungeonPartyFinderPlayer
{
    public const short Id = 5806;

    public DungeonPartyFinderPlayer(ulong playerId, string playerName, sbyte breed, bool sex, ushort level)
    {
        PlayerId = playerId;
        PlayerName = playerName;
        Breed = breed;
        Sex = sex;
        Level = level;
    }

    public DungeonPartyFinderPlayer()
    {
    }

    public virtual short TypeId => Id;

    public ulong PlayerId { get; set; }

    public string PlayerName { get; set; }

    public sbyte Breed { get; set; }

    public bool Sex { get; set; }

    public ushort Level { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(PlayerId);
        writer.WriteUTF(PlayerName);
        writer.WriteSByte(Breed);
        writer.WriteBoolean(Sex);
        writer.WriteVarUShort(Level);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        PlayerId = reader.ReadVarULong();
        PlayerName = reader.ReadUTF();
        Breed = reader.ReadSByte();
        Sex = reader.ReadBoolean();
        Level = reader.ReadVarUShort();
    }
}