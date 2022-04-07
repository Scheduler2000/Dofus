using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightTurnFinishMessage : Message
{
    public const uint Id = 6692;

    public GameFightTurnFinishMessage(bool isAfk)
    {
        IsAfk = isAfk;
    }

    public GameFightTurnFinishMessage()
    {
    }

    public override uint MessageId => Id;

    public bool IsAfk { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(IsAfk);
    }

    public override void Deserialize(IDataReader reader)
    {
        IsAfk = reader.ReadBoolean();
    }
}