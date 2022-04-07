using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PartyMemberArenaInformations : PartyMemberInformations
{
    public new const short Id = 2694;

    public PartyMemberArenaInformations(ulong objectId,
        string name,
        ushort level,
        EntityLook entityLook,
        sbyte breed,
        bool sex,
        uint lifePoints,
        uint maxLifePoints,
        ushort prospecting,
        byte regenRate,
        ushort initiative,
        sbyte alignmentSide,
        short worldX,
        short worldY,
        double mapId,
        ushort subAreaId,
        PlayerStatus status,
        IEnumerable<PartyEntityBaseInformation> entities,
        ushort rank)
    {
        ObjectId = objectId;
        Name = name;
        Level = level;
        EntityLook = entityLook;
        Breed = breed;
        Sex = sex;
        LifePoints = lifePoints;
        MaxLifePoints = maxLifePoints;
        Prospecting = prospecting;
        RegenRate = regenRate;
        Initiative = initiative;
        AlignmentSide = alignmentSide;
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
        SubAreaId = subAreaId;
        Status = status;
        Entities = entities;
        Rank = rank;
    }

    public PartyMemberArenaInformations()
    {
    }

    public override short TypeId => Id;

    public ushort Rank { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(Rank);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Rank = reader.ReadVarUShort();
    }
}