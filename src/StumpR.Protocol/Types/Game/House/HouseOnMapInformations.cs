using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HouseOnMapInformations : HouseInformations
{
    public new const short Id = 8890;

    public HouseOnMapInformations(uint houseId,
        ushort modelId,
        IEnumerable<int> doorsOnMap,
        IEnumerable<HouseInstanceInformations> houseInstances)
    {
        HouseId = houseId;
        ModelId = modelId;
        DoorsOnMap = doorsOnMap;
        HouseInstances = houseInstances;
    }

    public HouseOnMapInformations()
    {
    }

    public override short TypeId => Id;

    public IEnumerable<int> DoorsOnMap { get; set; }

    public IEnumerable<HouseInstanceInformations> HouseInstances { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) DoorsOnMap.Count());
        foreach (int objectToSend in DoorsOnMap) writer.WriteInt(objectToSend);
        writer.WriteShort((short) HouseInstances.Count());
        foreach (HouseInstanceInformations objectToSend in HouseInstances) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort doorsOnMapCount = reader.ReadUShort();
        var doorsOnMap_ = new int[doorsOnMapCount];

        for (var doorsOnMapIndex = 0; doorsOnMapIndex < doorsOnMapCount; doorsOnMapIndex++)
            doorsOnMap_[doorsOnMapIndex] = reader.ReadInt();
        DoorsOnMap = doorsOnMap_;
        ushort houseInstancesCount = reader.ReadUShort();
        var houseInstances_ = new HouseInstanceInformations[houseInstancesCount];

        for (var houseInstancesIndex = 0; houseInstancesIndex < houseInstancesCount; houseInstancesIndex++)
        {
            var objectToAdd = new HouseInstanceInformations();
            objectToAdd.Deserialize(reader);
            houseInstances_[houseInstancesIndex] = objectToAdd;
        }
        HouseInstances = houseInstances_;
    }
}