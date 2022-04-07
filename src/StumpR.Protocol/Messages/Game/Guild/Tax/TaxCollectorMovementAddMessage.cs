using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TaxCollectorMovementAddMessage : Message
{
    public const uint Id = 6509;

    public TaxCollectorMovementAddMessage(TaxCollectorInformations informations)
    {
        Informations = informations;
    }

    public TaxCollectorMovementAddMessage()
    {
    }

    public override uint MessageId => Id;

    public TaxCollectorInformations Informations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(Informations.TypeId);
        Informations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Informations = ProtocolTypeManager.GetInstance<TaxCollectorInformations>(reader.ReadShort());
        Informations.Deserialize(reader);
    }
}