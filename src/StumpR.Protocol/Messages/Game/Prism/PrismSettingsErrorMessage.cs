using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismSettingsErrorMessage : Message
{
    public const uint Id = 2594;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}