using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PaddockPropertiesMessage : Message
{
    public const uint Id = 3194;

    public PaddockPropertiesMessage(PaddockInstancesInformations properties)
    {
        Properties = properties;
    }

    public PaddockPropertiesMessage()
    {
    }

    public override uint MessageId => Id;

    public PaddockInstancesInformations Properties { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Properties.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Properties = new PaddockInstancesInformations();
        Properties.Deserialize(reader);
    }
}