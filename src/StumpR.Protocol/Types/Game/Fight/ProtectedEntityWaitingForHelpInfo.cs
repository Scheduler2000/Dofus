using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ProtectedEntityWaitingForHelpInfo
{
    public const short Id = 2847;

    public ProtectedEntityWaitingForHelpInfo(int timeLeftBeforeFight, int waitTimeForPlacement, sbyte nbPositionForDefensors)
    {
        TimeLeftBeforeFight = timeLeftBeforeFight;
        WaitTimeForPlacement = waitTimeForPlacement;
        NbPositionForDefensors = nbPositionForDefensors;
    }

    public ProtectedEntityWaitingForHelpInfo()
    {
    }

    public virtual short TypeId => Id;

    public int TimeLeftBeforeFight { get; set; }

    public int WaitTimeForPlacement { get; set; }

    public sbyte NbPositionForDefensors { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteInt(TimeLeftBeforeFight);
        writer.WriteInt(WaitTimeForPlacement);
        writer.WriteSByte(NbPositionForDefensors);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        TimeLeftBeforeFight = reader.ReadInt();
        WaitTimeForPlacement = reader.ReadInt();
        NbPositionForDefensors = reader.ReadSByte();
    }
}