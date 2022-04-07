using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HouseInformationsInside : HouseInformations
{
    public new const short Id = 2517;

    public HouseInformationsInside(uint houseId, ushort modelId, HouseInstanceInformations houseInfos, short worldX, short worldY)
    {
        HouseId = houseId;
        ModelId = modelId;
        HouseInfos = houseInfos;
        WorldX = worldX;
        WorldY = worldY;
    }

    public HouseInformationsInside()
    {
    }

    public override short TypeId => Id;

    public HouseInstanceInformations HouseInfos { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(HouseInfos.TypeId);
        HouseInfos.Serialize(writer);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        HouseInfos = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadShort());
        HouseInfos.Deserialize(reader);
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
    }
}