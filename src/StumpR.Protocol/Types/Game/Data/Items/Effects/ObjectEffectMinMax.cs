using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ObjectEffectMinMax : ObjectEffect
{
    public new const short Id = 5720;

    public ObjectEffectMinMax(ushort actionId, uint min, uint max)
    {
        ActionId = actionId;
        Min = min;
        Max = max;
    }

    public ObjectEffectMinMax()
    {
    }

    public override short TypeId => Id;

    public uint Min { get; set; }

    public uint Max { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(Min);
        writer.WriteVarUInt(Max);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Min = reader.ReadVarUInt();
        Max = reader.ReadVarUInt();
    }
}