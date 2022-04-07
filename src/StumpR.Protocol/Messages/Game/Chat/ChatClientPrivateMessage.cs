using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChatClientPrivateMessage : ChatAbstractClientMessage
{
    public new const uint Id = 1814;

    public ChatClientPrivateMessage(string content, AbstractPlayerSearchInformation receiver)
    {
        Content = content;
        Receiver = receiver;
    }

    public ChatClientPrivateMessage()
    {
    }

    public override uint MessageId => Id;

    public AbstractPlayerSearchInformation Receiver { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(Receiver.TypeId);
        Receiver.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Receiver = ProtocolTypeManager.GetInstance<AbstractPlayerSearchInformation>(reader.ReadShort());
        Receiver.Deserialize(reader);
    }
}