using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismFightStateUpdateMessage : Message
{
    public const uint Id = 7379;

    public PrismFightStateUpdateMessage(sbyte state)
    {
        State = state;
    }

    public PrismFightStateUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte State { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(State);
    }

    public override void Deserialize(IDataReader reader)
    {
        State = reader.ReadSByte();
    }
}