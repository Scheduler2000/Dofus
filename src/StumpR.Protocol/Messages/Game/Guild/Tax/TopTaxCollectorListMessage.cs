using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TopTaxCollectorListMessage : AbstractTaxCollectorListMessage
{
    public new const uint Id = 3617;

    public TopTaxCollectorListMessage(IEnumerable<TaxCollectorInformations> informations, bool isDungeon)
    {
        Informations = informations;
        IsDungeon = isDungeon;
    }

    public TopTaxCollectorListMessage()
    {
    }

    public override uint MessageId => Id;

    public bool IsDungeon { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteBoolean(IsDungeon);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        IsDungeon = reader.ReadBoolean();
    }
}