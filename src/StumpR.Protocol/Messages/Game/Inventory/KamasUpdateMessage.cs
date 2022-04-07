using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class KamasUpdateMessage : Message
{
    public const uint Id = 4370;

    public KamasUpdateMessage(ulong kamasTotal)
    {
        KamasTotal = kamasTotal;
    }

    public KamasUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong KamasTotal { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(KamasTotal);
    }

    public override void Deserialize(IDataReader reader)
    {
        KamasTotal = reader.ReadVarULong();
    }
}