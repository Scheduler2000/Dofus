using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightEffectTriggerCount
{
    public const short Id = 3026;

    public GameFightEffectTriggerCount(uint effectId, double targetId, sbyte count)
    {
        EffectId = effectId;
        TargetId = targetId;
        Count = count;
    }

    public GameFightEffectTriggerCount()
    {
    }

    public virtual short TypeId => Id;

    public uint EffectId { get; set; }

    public double TargetId { get; set; }

    public sbyte Count { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(EffectId);
        writer.WriteDouble(TargetId);
        writer.WriteSByte(Count);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        EffectId = reader.ReadVarUInt();
        TargetId = reader.ReadDouble();
        Count = reader.ReadSByte();
    }
}