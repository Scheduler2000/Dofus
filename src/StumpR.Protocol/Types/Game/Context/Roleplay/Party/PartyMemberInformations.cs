using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PartyMemberInformations : CharacterBaseInformations
{
    public new const short Id = 8492;

    public PartyMemberInformations(ulong objectId,
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
        IEnumerable<PartyEntityBaseInformation> entities)
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
    }

    public PartyMemberInformations()
    {
    }

    public override short TypeId => Id;

    public uint LifePoints { get; set; }

    public uint MaxLifePoints { get; set; }

    public ushort Prospecting { get; set; }

    public byte RegenRate { get; set; }

    public ushort Initiative { get; set; }

    public sbyte AlignmentSide { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public double MapId { get; set; }

    public ushort SubAreaId { get; set; }

    public PlayerStatus Status { get; set; }

    public IEnumerable<PartyEntityBaseInformation> Entities { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(LifePoints);
        writer.WriteVarUInt(MaxLifePoints);
        writer.WriteVarUShort(Prospecting);
        writer.WriteByte(RegenRate);
        writer.WriteVarUShort(Initiative);
        writer.WriteSByte(AlignmentSide);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteDouble(MapId);
        writer.WriteVarUShort(SubAreaId);
        writer.WriteShort(Status.TypeId);
        Status.Serialize(writer);
        writer.WriteShort((short) Entities.Count());

        foreach (PartyEntityBaseInformation objectToSend in Entities)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        LifePoints = reader.ReadVarUInt();
        MaxLifePoints = reader.ReadVarUInt();
        Prospecting = reader.ReadVarUShort();
        RegenRate = reader.ReadByte();
        Initiative = reader.ReadVarUShort();
        AlignmentSide = reader.ReadSByte();
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        MapId = reader.ReadDouble();
        SubAreaId = reader.ReadVarUShort();
        Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
        Status.Deserialize(reader);
        ushort entitiesCount = reader.ReadUShort();
        var entities_ = new PartyEntityBaseInformation[entitiesCount];

        for (var entitiesIndex = 0; entitiesIndex < entitiesCount; entitiesIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<PartyEntityBaseInformation>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            entities_[entitiesIndex] = objectToAdd;
        }
        Entities = entities_;
    }
}