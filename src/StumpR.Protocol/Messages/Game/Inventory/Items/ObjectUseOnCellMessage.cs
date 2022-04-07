using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectUseOnCellMessage : ObjectUseMessage
{
    public new const uint Id = 5623;

    public ObjectUseOnCellMessage(uint objectUID, ushort cells)
    {
        ObjectUID = objectUID;
        Cells = cells;
    }

    public ObjectUseOnCellMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort Cells { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUShort(Cells);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Cells = reader.ReadVarUShort();
    }
}