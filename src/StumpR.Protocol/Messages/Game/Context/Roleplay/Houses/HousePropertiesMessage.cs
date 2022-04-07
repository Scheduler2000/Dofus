using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class HousePropertiesMessage : Message
{
    public const uint Id = 3830;

    public HousePropertiesMessage(uint houseId, IEnumerable<int> doorsOnMap, HouseInstanceInformations properties)
    {
        HouseId = houseId;
        DoorsOnMap = doorsOnMap;
        Properties = properties;
    }

    public HousePropertiesMessage()
    {
    }

    public override uint MessageId => Id;

    public uint HouseId { get; set; }

    public IEnumerable<int> DoorsOnMap { get; set; }

    public HouseInstanceInformations Properties { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(HouseId);
        writer.WriteShort((short) DoorsOnMap.Count());
        foreach (int objectToSend in DoorsOnMap) writer.WriteInt(objectToSend);
        writer.WriteShort(Properties.TypeId);
        Properties.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        HouseId = reader.ReadVarUInt();
        ushort doorsOnMapCount = reader.ReadUShort();
        var doorsOnMap_ = new int[doorsOnMapCount];

        for (var doorsOnMapIndex = 0; doorsOnMapIndex < doorsOnMapCount; doorsOnMapIndex++)
            doorsOnMap_[doorsOnMapIndex] = reader.ReadInt();
        DoorsOnMap = doorsOnMap_;
        Properties = ProtocolTypeManager.GetInstance<HouseInstanceInformations>(reader.ReadShort());
        Properties.Deserialize(reader);
    }
}