using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FriendSpouseInformations
{
    public const short Id = 9956;

    public FriendSpouseInformations(int spouseAccountId,
        ulong spouseId,
        string spouseName,
        ushort spouseLevel,
        sbyte breed,
        sbyte sex,
        EntityLook spouseEntityLook,
        GuildInformations guildInfo,
        sbyte alignmentSide)
    {
        SpouseAccountId = spouseAccountId;
        SpouseId = spouseId;
        SpouseName = spouseName;
        SpouseLevel = spouseLevel;
        Breed = breed;
        Sex = sex;
        SpouseEntityLook = spouseEntityLook;
        GuildInfo = guildInfo;
        AlignmentSide = alignmentSide;
    }

    public FriendSpouseInformations()
    {
    }

    public virtual short TypeId => Id;

    public int SpouseAccountId { get; set; }

    public ulong SpouseId { get; set; }

    public string SpouseName { get; set; }

    public ushort SpouseLevel { get; set; }

    public sbyte Breed { get; set; }

    public sbyte Sex { get; set; }

    public EntityLook SpouseEntityLook { get; set; }

    public GuildInformations GuildInfo { get; set; }

    public sbyte AlignmentSide { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(SpouseAccountId);
        writer.WriteVarULong(SpouseId);
        writer.WriteUTF(SpouseName);
        writer.WriteVarUShort(SpouseLevel);
        writer.WriteSByte(Breed);
        writer.WriteSByte(Sex);
        SpouseEntityLook.Serialize(writer);
        GuildInfo.Serialize(writer);
        writer.WriteSByte(AlignmentSide);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        SpouseAccountId = reader.ReadInt();
        SpouseId = reader.ReadVarULong();
        SpouseName = reader.ReadUTF();
        SpouseLevel = reader.ReadVarUShort();
        Breed = reader.ReadSByte();
        Sex = reader.ReadSByte();
        SpouseEntityLook = new EntityLook();
        SpouseEntityLook.Deserialize(reader);
        GuildInfo = new GuildInformations();
        GuildInfo.Deserialize(reader);
        AlignmentSide = reader.ReadSByte();
    }
}