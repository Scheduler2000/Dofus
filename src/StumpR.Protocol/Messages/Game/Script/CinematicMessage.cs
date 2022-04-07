using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CinematicMessage : Message
{
    public const uint Id = 5054;

    public CinematicMessage(ushort cinematicId)
    {
        CinematicId = cinematicId;
    }

    public CinematicMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort CinematicId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(CinematicId);
    }

    public override void Deserialize(IDataReader reader)
    {
        CinematicId = reader.ReadVarUShort();
    }
}