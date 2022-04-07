using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachInvitationAnswerMessage : Message
{
    public const uint Id = 5975;

    public BreachInvitationAnswerMessage(bool accept)
    {
        Accept = accept;
    }

    public BreachInvitationAnswerMessage()
    {
    }

    public override uint MessageId => Id;

    public bool Accept { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(Accept);
    }

    public override void Deserialize(IDataReader reader)
    {
        Accept = reader.ReadBoolean();
    }
}