using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SpouseStatusMessage : Message
{
    public const uint Id = 5406;

    public SpouseStatusMessage(bool hasSpouse)
    {
        HasSpouse = hasSpouse;
    }

    public SpouseStatusMessage()
    {
    }

    public override uint MessageId => Id;

    public bool HasSpouse { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(HasSpouse);
    }

    public override void Deserialize(IDataReader reader)
    {
        HasSpouse = reader.ReadBoolean();
    }
}