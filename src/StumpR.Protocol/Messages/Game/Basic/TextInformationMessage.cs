using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class TextInformationMessage : Message
{
    public const uint Id = 3712;

    public TextInformationMessage(sbyte msgType, ushort msgId, IEnumerable<string> parameters)
    {
        MsgType = msgType;
        MsgId = msgId;
        Parameters = parameters;
    }

    public TextInformationMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte MsgType { get; set; }

    public ushort MsgId { get; set; }

    public IEnumerable<string> Parameters { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(MsgType);
        writer.WriteVarUShort(MsgId);
        writer.WriteShort((short) Parameters.Count());
        foreach (string objectToSend in Parameters) writer.WriteUTF(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        MsgType = reader.ReadSByte();
        MsgId = reader.ReadVarUShort();
        ushort parametersCount = reader.ReadUShort();
        var parameters_ = new string[parametersCount];

        for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
            parameters_[parametersIndex] = reader.ReadUTF();
        Parameters = parameters_;
    }
}