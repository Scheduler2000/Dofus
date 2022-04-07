using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StorageKamasUpdateMessage : Message
{
    public const uint Id = 4689;

    public StorageKamasUpdateMessage(ulong kamasTotal)
    {
        KamasTotal = kamasTotal;
    }

    public StorageKamasUpdateMessage()
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