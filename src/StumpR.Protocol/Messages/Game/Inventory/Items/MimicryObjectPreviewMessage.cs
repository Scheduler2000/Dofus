using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MimicryObjectPreviewMessage : Message
{
    public const uint Id = 1198;

    public MimicryObjectPreviewMessage(ObjectItem result)
    {
        Result = result;
    }

    public MimicryObjectPreviewMessage()
    {
    }

    public override uint MessageId => Id;

    public ObjectItem Result { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Result.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Result = new ObjectItem();
        Result.Deserialize(reader);
    }
}