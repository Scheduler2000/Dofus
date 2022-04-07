using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AtlasPointInformationsMessage : Message
{
    public const uint Id = 6676;

    public AtlasPointInformationsMessage(AtlasPointsInformations type)
    {
        Type = type;
    }

    public AtlasPointInformationsMessage()
    {
    }

    public override uint MessageId => Id;

    public AtlasPointsInformations Type { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Type.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Type = new AtlasPointsInformations();
        Type.Deserialize(reader);
    }
}