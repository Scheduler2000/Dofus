using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismsListUpdateMessage : PrismsListMessage
{
    public new const uint Id = 2634;

    public PrismsListUpdateMessage(IEnumerable<PrismSubareaEmptyInfo> prisms)
    {
        Prisms = prisms;
    }

    public PrismsListUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}