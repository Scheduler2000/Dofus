using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HouseInformationsForGuild : HouseInformations
{
    public new const short Id = 3219;

    public HouseInformationsForGuild(uint houseId,
        ushort modelId,
        int instanceId,
        bool secondHand,
        AccountTagInformation ownerTag,
        short worldX,
        short worldY,
        double mapId,
        ushort subAreaId,
        IEnumerable<int> skillListIds,
        uint guildshareParams)
    {
        HouseId = houseId;
        ModelId = modelId;
        InstanceId = instanceId;
        SecondHand = secondHand;
        OwnerTag = ownerTag;
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
        SubAreaId = subAreaId;
        SkillListIds = skillListIds;
        GuildshareParams = guildshareParams;
    }

    public HouseInformationsForGuild()
    {
    }

    public override short TypeId => Id;

    public int InstanceId { get; set; }

    public bool SecondHand { get; set; }

    public AccountTagInformation OwnerTag { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public double MapId { get; set; }

    public ushort SubAreaId { get; set; }

    public IEnumerable<int> SkillListIds { get; set; }

    public uint GuildshareParams { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(InstanceId);
        writer.WriteBoolean(SecondHand);
        OwnerTag.Serialize(writer);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteDouble(MapId);
        writer.WriteVarUShort(SubAreaId);
        writer.WriteShort((short) SkillListIds.Count());
        foreach (int objectToSend in SkillListIds) writer.WriteInt(objectToSend);
        writer.WriteVarUInt(GuildshareParams);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        InstanceId = reader.ReadInt();
        SecondHand = reader.ReadBoolean();
        OwnerTag = new AccountTagInformation();
        OwnerTag.Deserialize(reader);
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        MapId = reader.ReadDouble();
        SubAreaId = reader.ReadVarUShort();
        ushort skillListIdsCount = reader.ReadUShort();
        var skillListIds_ = new int[skillListIdsCount];

        for (var skillListIdsIndex = 0; skillListIdsIndex < skillListIdsCount; skillListIdsIndex++)
            skillListIds_[skillListIdsIndex] = reader.ReadInt();
        SkillListIds = skillListIds_;
        GuildshareParams = reader.ReadVarUInt();
    }
}