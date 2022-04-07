using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AllianceInsiderPrismInformation : PrismInformation
{
    public new const short Id = 8201;

    public AllianceInsiderPrismInformation(sbyte typeId,
        sbyte state,
        int nextVulnerabilityDate,
        int placementDate,
        uint rewardTokenCount,
        int lastTimeSlotModificationDate,
        uint lastTimeSlotModificationAuthorGuildId,
        ulong lastTimeSlotModificationAuthorId,
        string lastTimeSlotModificationAuthorName,
        IEnumerable<ObjectItem> modulesObjects)
    {
        this.typeId = typeId;
        State = state;
        NextVulnerabilityDate = nextVulnerabilityDate;
        PlacementDate = placementDate;
        RewardTokenCount = rewardTokenCount;
        LastTimeSlotModificationDate = lastTimeSlotModificationDate;
        LastTimeSlotModificationAuthorGuildId = lastTimeSlotModificationAuthorGuildId;
        LastTimeSlotModificationAuthorId = lastTimeSlotModificationAuthorId;
        LastTimeSlotModificationAuthorName = lastTimeSlotModificationAuthorName;
        ModulesObjects = modulesObjects;
    }

    public AllianceInsiderPrismInformation()
    {
    }

    public override short TypeId => Id;

    public int LastTimeSlotModificationDate { get; set; }

    public uint LastTimeSlotModificationAuthorGuildId { get; set; }

    public ulong LastTimeSlotModificationAuthorId { get; set; }

    public string LastTimeSlotModificationAuthorName { get; set; }

    public IEnumerable<ObjectItem> ModulesObjects { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteInt(LastTimeSlotModificationDate);
        writer.WriteVarUInt(LastTimeSlotModificationAuthorGuildId);
        writer.WriteVarULong(LastTimeSlotModificationAuthorId);
        writer.WriteUTF(LastTimeSlotModificationAuthorName);
        writer.WriteShort((short) ModulesObjects.Count());
        foreach (ObjectItem objectToSend in ModulesObjects) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        LastTimeSlotModificationDate = reader.ReadInt();
        LastTimeSlotModificationAuthorGuildId = reader.ReadVarUInt();
        LastTimeSlotModificationAuthorId = reader.ReadVarULong();
        LastTimeSlotModificationAuthorName = reader.ReadUTF();
        ushort modulesObjectsCount = reader.ReadUShort();
        var modulesObjects_ = new ObjectItem[modulesObjectsCount];

        for (var modulesObjectsIndex = 0; modulesObjectsIndex < modulesObjectsCount; modulesObjectsIndex++)
        {
            var objectToAdd = new ObjectItem();
            objectToAdd.Deserialize(reader);
            modulesObjects_[modulesObjectsIndex] = objectToAdd;
        }
        ModulesObjects = modulesObjects_;
    }
}