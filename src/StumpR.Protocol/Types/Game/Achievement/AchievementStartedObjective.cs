using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AchievementStartedObjective : AchievementObjective
{
    public new const short Id = 5823;

    public AchievementStartedObjective(uint objectId, ushort maxValue, ushort value)
    {
        ObjectId = objectId;
        MaxValue = maxValue;
        Value = value;
    }

    public AchievementStartedObjective()
    {
    }

    public override short TypeId => Id;

    public ushort Value { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(Value);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Value = reader.ReadVarUShort();
    }
}