using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TreasureHuntMessage : Message
{
    public const uint Id = 4513;

    public TreasureHuntMessage(sbyte questType,
        double startMapId,
        IEnumerable<TreasureHuntStep> knownStepsList,
        sbyte totalStepCount,
        uint checkPointCurrent,
        uint checkPointTotal,
        int availableRetryCount,
        IEnumerable<TreasureHuntFlag> flags)
    {
        QuestType = questType;
        StartMapId = startMapId;
        KnownStepsList = knownStepsList;
        TotalStepCount = totalStepCount;
        CheckPointCurrent = checkPointCurrent;
        CheckPointTotal = checkPointTotal;
        AvailableRetryCount = availableRetryCount;
        Flags = flags;
    }

    public TreasureHuntMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte QuestType { get; set; }

    public double StartMapId { get; set; }

    public IEnumerable<TreasureHuntStep> KnownStepsList { get; set; }

    public sbyte TotalStepCount { get; set; }

    public uint CheckPointCurrent { get; set; }

    public uint CheckPointTotal { get; set; }

    public int AvailableRetryCount { get; set; }

    public IEnumerable<TreasureHuntFlag> Flags { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(QuestType);
        writer.WriteDouble(StartMapId);
        writer.WriteShort((short) KnownStepsList.Count());

        foreach (TreasureHuntStep objectToSend in KnownStepsList)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteSByte(TotalStepCount);
        writer.WriteVarUInt(CheckPointCurrent);
        writer.WriteVarUInt(CheckPointTotal);
        writer.WriteInt(AvailableRetryCount);
        writer.WriteShort((short) Flags.Count());
        foreach (TreasureHuntFlag objectToSend in Flags) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        QuestType = reader.ReadSByte();
        StartMapId = reader.ReadDouble();
        ushort knownStepsListCount = reader.ReadUShort();
        var knownStepsList_ = new TreasureHuntStep[knownStepsListCount];

        for (var knownStepsListIndex = 0; knownStepsListIndex < knownStepsListCount; knownStepsListIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<TreasureHuntStep>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            knownStepsList_[knownStepsListIndex] = objectToAdd;
        }
        KnownStepsList = knownStepsList_;
        TotalStepCount = reader.ReadSByte();
        CheckPointCurrent = reader.ReadVarUInt();
        CheckPointTotal = reader.ReadVarUInt();
        AvailableRetryCount = reader.ReadInt();
        ushort flagsCount = reader.ReadUShort();
        var flags_ = new TreasureHuntFlag[flagsCount];

        for (var flagsIndex = 0; flagsIndex < flagsCount; flagsIndex++)
        {
            var objectToAdd = new TreasureHuntFlag();
            objectToAdd.Deserialize(reader);
            flags_[flagsIndex] = objectToAdd;
        }
        Flags = flags_;
    }
}