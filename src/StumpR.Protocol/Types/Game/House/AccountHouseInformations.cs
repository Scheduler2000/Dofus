using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AccountHouseInformations : HouseInformations
{
    public new const short Id = 3170;

    public AccountHouseInformations(uint houseId,
        ushort modelId,
        HouseInstanceInformations houseInfos,
        short worldX,
        short worldY,
        double mapId,
        ushort subAreaId)
    {
        HouseId = houseId;
        ModelId = modelId;
        HouseInfos = houseInfos;
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
        SubAreaId = subAreaId;
    }

    public AccountHouseInformations()
    {
    }

    public override short TypeId => Id;

    public HouseInstanceInformations HouseInfos { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public double MapId { get; set; }

    public ushort SubAreaId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(HouseInfos.TypeId);
        HouseInfos.Serialize(writer);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteDouble(MapId);
        writer.WriteVarUShort(SubAreaId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        HouseInfos = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadShort());
        HouseInfos.Deserialize(reader);
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        MapId = reader.ReadDouble();
        SubAreaId = reader.ReadVarUShort();
    }
}