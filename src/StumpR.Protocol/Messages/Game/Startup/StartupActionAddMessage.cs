using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StartupActionAddMessage : Message
{
    public const uint Id = 1592;

    public StartupActionAddMessage(StartupActionAddObject newAction)
    {
        NewAction = newAction;
    }

    public StartupActionAddMessage()
    {
    }

    public override uint MessageId => Id;

    public StartupActionAddObject NewAction { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        NewAction.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        NewAction = new StartupActionAddObject();
        NewAction.Deserialize(reader);
    }
}