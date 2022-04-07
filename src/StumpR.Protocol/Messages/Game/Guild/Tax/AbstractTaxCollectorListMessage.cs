using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AbstractTaxCollectorListMessage : Message
{
    public const uint Id = 6496;

    public AbstractTaxCollectorListMessage(IEnumerable<TaxCollectorInformations> informations)
    {
        Informations = informations;
    }

    public AbstractTaxCollectorListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<TaxCollectorInformations> Informations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Informations.Count());

        foreach (TaxCollectorInformations objectToSend in Informations)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort informationsCount = reader.ReadUShort();
        var informations_ = new TaxCollectorInformations[informationsCount];

        for (var informationsIndex = 0; informationsIndex < informationsCount; informationsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            informations_[informationsIndex] = objectToAdd;
        }
        Informations = informations_;
    }
}