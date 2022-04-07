using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class KamaDebtInformation : DebtInformation
{
    public new const short Id = 2979;

    public KamaDebtInformation(double objectId, double timestamp, ulong kamas)
    {
        ObjectId = objectId;
        Timestamp = timestamp;
        Kamas = kamas;
    }

    public KamaDebtInformation()
    {
    }

    public override short TypeId => Id;

    public ulong Kamas { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(Kamas);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Kamas = reader.ReadVarULong();
    }
}