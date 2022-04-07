using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightLeaveMessage : Message
{
    public const uint Id = 4663;

    public GameFightLeaveMessage(double charId)
    {
        CharId = charId;
    }

    public GameFightLeaveMessage()
    {
    }

    public override uint MessageId => Id;

    public double CharId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(CharId);
    }

    public override void Deserialize(IDataReader reader)
    {
        CharId = reader.ReadDouble();
    }
}