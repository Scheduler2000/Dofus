using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StartupActionsExecuteMessage : Message
{
    public const uint Id = 8834;

    public override uint MessageId => Id;

    public override void Serialize(IDataWriter writer)
    {
    }

    public override void Deserialize(IDataReader reader)
    {
    }
}