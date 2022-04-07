using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class HumanOptionObjectUse : HumanOption
{
    public new const short Id = 1192;

    public HumanOptionObjectUse(sbyte delayTypeId, double delayEndTime, ushort objectGID)
    {
        DelayTypeId = delayTypeId;
        DelayEndTime = delayEndTime;
        ObjectGID = objectGID;
    }

    public HumanOptionObjectUse()
    {
    }

    public override short TypeId => Id;

    public sbyte DelayTypeId { get; set; }

    public double DelayEndTime { get; set; }

    public ushort ObjectGID { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(DelayTypeId);
        writer.WriteDouble(DelayEndTime);
        writer.WriteVarUShort(ObjectGID);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        DelayTypeId = reader.ReadSByte();
        DelayEndTime = reader.ReadDouble();
        ObjectGID = reader.ReadVarUShort();
    }
}