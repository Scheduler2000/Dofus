using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameMapChangeOrientationRequestMessage : Message
{
    public const uint Id = 4770;

    public GameMapChangeOrientationRequestMessage(sbyte direction)
    {
        Direction = direction;
    }

    public GameMapChangeOrientationRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Direction { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Direction);
    }

    public override void Deserialize(IDataReader reader)
    {
        Direction = reader.ReadSByte();
    }
}