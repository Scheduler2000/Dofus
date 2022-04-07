using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeGuildTaxCollectorGetMessage : Message
{
    public const uint Id = 962;

    public ExchangeGuildTaxCollectorGetMessage(string collectorName,
        short worldX,
        short worldY,
        double mapId,
        ushort subAreaId,
        string userName,
        ulong callerId,
        string callerName,
        double experience,
        ushort pods,
        IEnumerable<ObjectItemGenericQuantity> objectsInfos)
    {
        CollectorName = collectorName;
        WorldX = worldX;
        WorldY = worldY;
        MapId = mapId;
        SubAreaId = subAreaId;
        UserName = userName;
        CallerId = callerId;
        CallerName = callerName;
        Experience = experience;
        Pods = pods;
        ObjectsInfos = objectsInfos;
    }

    public ExchangeGuildTaxCollectorGetMessage()
    {
    }

    public override uint MessageId => Id;

    public string CollectorName { get; set; }

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public double MapId { get; set; }

    public ushort SubAreaId { get; set; }

    public string UserName { get; set; }

    public ulong CallerId { get; set; }

    public string CallerName { get; set; }

    public double Experience { get; set; }

    public ushort Pods { get; set; }

    public IEnumerable<ObjectItemGenericQuantity> ObjectsInfos { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteUTF(CollectorName);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
        writer.WriteDouble(MapId);
        writer.WriteVarUShort(SubAreaId);
        writer.WriteUTF(UserName);
        writer.WriteVarULong(CallerId);
        writer.WriteUTF(CallerName);
        writer.WriteDouble(Experience);
        writer.WriteVarUShort(Pods);
        writer.WriteShort((short) ObjectsInfos.Count());
        foreach (ObjectItemGenericQuantity objectToSend in ObjectsInfos) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        CollectorName = reader.ReadUTF();
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
        MapId = reader.ReadDouble();
        SubAreaId = reader.ReadVarUShort();
        UserName = reader.ReadUTF();
        CallerId = reader.ReadVarULong();
        CallerName = reader.ReadUTF();
        Experience = reader.ReadDouble();
        Pods = reader.ReadVarUShort();
        ushort objectsInfosCount = reader.ReadUShort();
        var objectsInfos_ = new ObjectItemGenericQuantity[objectsInfosCount];

        for (var objectsInfosIndex = 0; objectsInfosIndex < objectsInfosCount; objectsInfosIndex++)
        {
            var objectToAdd = new ObjectItemGenericQuantity();
            objectToAdd.Deserialize(reader);
            objectsInfos_[objectsInfosIndex] = objectToAdd;
        }
        ObjectsInfos = objectsInfos_;
    }
}