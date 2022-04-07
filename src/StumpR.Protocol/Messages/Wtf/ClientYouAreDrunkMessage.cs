using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ClientYouAreDrunkMessage : DebugInClientMessage
{
    public new const uint Id = 159;

    public ClientYouAreDrunkMessage(sbyte level, string message)
    {
        Level = level;
        Message = message;
    }

    public ClientYouAreDrunkMessage()
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