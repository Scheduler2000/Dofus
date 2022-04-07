using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightOptionToggleMessage : Message
{
    public const uint Id = 2382;

    public GameFightOptionToggleMessage(sbyte option)
    {
        Option = option;
    }

    public GameFightOptionToggleMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte Option { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(Option);
    }

    public override void Deserialize(IDataReader reader)
    {
        Option = reader.ReadSByte();
    }
}