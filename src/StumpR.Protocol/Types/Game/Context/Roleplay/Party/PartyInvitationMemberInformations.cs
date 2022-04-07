using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PartyInvitationMemberInformations : CharacterBaseInformations
{
    public new const short Id = 436;

    public PartyInvitationMemberInformations(ulong objectId,
        string name,
        ushort level,
        EntityLook entityLook,
        sbyte breed,
        bool sex,
        short worldX,
        short worldY,
        double mapId,
        ushort subAreaId,
        IEnumerable<PartyEntityBaseInformation> entities)
    {
        ObjectId = objectId;
        Name = name;
        Level = level;
        EntityLook = entityLook;
        Breed = breed;
        Sex = sex;
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
        SubAreaId = subAreaId;
        Entities = entities;
    }

    public PartyInvitationMemberInformations()
    {
    }

    public override short TypeId => Id;

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public double MapId { get; set; }

    public ushort SubAreaId { get; set; }

    public IEnumerable<PartyEntityBaseInformation> Entities { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteDouble(MapId);
        writer.WriteVarUShort(SubAreaId);
        writer.WriteShort((short) Entities.Count());
        foreach (PartyEntityBaseInformation objectToSend in Entities) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        MapId = reader.ReadDouble();
        SubAreaId = reader.ReadVarUShort();
        ushort entitiesCount = reader.ReadUShort();
        var entities_ = new PartyEntityBaseInformation[entitiesCount];

        for (var entitiesIndex = 0; entitiesIndex < entitiesCount; entitiesIndex++)
        {
            var objectToAdd = new PartyEntityBaseInformation();
            objectToAdd.Deserialize(reader);
            entities_[entitiesIndex] = objectToAdd;
        }
        Entities = entities_;
    }
}