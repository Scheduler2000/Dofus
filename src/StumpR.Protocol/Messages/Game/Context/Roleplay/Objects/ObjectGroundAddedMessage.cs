using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectGroundAddedMessage : Message
{
    public const uint Id = 3936;

    public ObjectGroundAddedMessage(ushort cellId, ushort objectGID)
    {
        CellId = cellId;
        ObjectGID = objectGID;
    }

    public ObjectGroundAddedMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort CellId { get; set; }

    public ushort ObjectGID { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(CellId);
        writer.WriteVarUShort(ObjectGID);
    }

    public override void Deserialize(IDataReader reader)
    {
        CellId = reader.ReadVarUShort();
        ObjectGID = reader.ReadVarUShort();
    }
}