using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeMountsStableBornAddMessage : ExchangeMountsStableAddMessage
{
    public new const uint Id = 1340;

    public ExchangeMountsStableBornAddMessage(IEnumerable<MountClientData> mountDescription)
    {
        MountDescription = mountDescription;
    }

    public ExchangeMountsStableBornAddMessage()
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