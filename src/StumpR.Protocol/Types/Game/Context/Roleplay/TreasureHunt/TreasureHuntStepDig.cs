using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class TreasureHuntStepDig : TreasureHuntStep
{
    public new const short Id = 199;


    public override short TypeId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}