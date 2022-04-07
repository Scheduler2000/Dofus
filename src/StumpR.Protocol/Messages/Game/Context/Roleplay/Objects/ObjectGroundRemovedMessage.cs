using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectGroundRemovedMessage : Message
{
    public const uint Id = 7554;

    public ObjectGroundRemovedMessage(ushort cell)
    {
        Cell = cell;
    }

    public ObjectGroundRemovedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort Cell { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(Cell);
    }

    public override void Deserialize(IDataReader reader)
    {
        Cell = reader.ReadVarUShort();
    }
}