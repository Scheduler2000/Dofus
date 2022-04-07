using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class CheckIntegrityMessage : Message
{
    public const uint Id = 1296;

    public CheckIntegrityMessage(IEnumerable<sbyte> data)
    {
        Data = data;
    }

    public CheckIntegrityMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<sbyte> Data { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarInt(Data.Count());
        foreach (sbyte objectToSend in Data) writer.WriteSByte(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        int dataCount = reader.ReadVarInt();
        var data_ = new sbyte[dataCount];
        for (var dataIndex = 0; dataIndex < dataCount; dataIndex++) data_[dataIndex] = reader.ReadSByte();
        Data = data_;
    }
}