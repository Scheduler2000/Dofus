using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class PrismGeolocalizedInformation : PrismSubareaEmptyInfo
{
    public new const short Id = 2406;

    public PrismGeolocalizedInformation(ushort subAreaId,
        uint allianceId,
        short worldX,
        short worldY,
        double mapId,
        PrismInformation prism)
    {
        SubAreaId = subAreaId;
        AllianceId = allianceId;
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
        Prism = prism;
    }

    public PrismGeolocalizedInformation()
    {
    }

    public override short TypeId => Id;

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public double MapId { get; set; }

    public PrismInformation Prism { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteDouble(MapId);
        writer.WriteShort(Prism.TypeId);
        Prism.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        MapId = reader.ReadDouble();
        Prism = ProtocolTypeManager.GetInstance<PrismInformation>(reader.ReadShort());
        Prism.Deserialize(reader);
    }
}