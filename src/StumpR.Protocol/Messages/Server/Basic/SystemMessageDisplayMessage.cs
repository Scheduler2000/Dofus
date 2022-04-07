using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SystemMessageDisplayMessage : Message
{
    public const uint Id = 4698;

    public SystemMessageDisplayMessage(bool hangUp, ushort msgId, IEnumerable<string> parameters)
    {
        HangUp = hangUp;
        MsgId = msgId;
        Parameters = parameters;
    }

    public SystemMessageDisplayMessage()
    {
    }

    public override uint MessageId => Id;

    public bool HangUp { get; set; }

    public ushort MsgId { get; set; }

    public IEnumerable<string> Parameters { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteBoolean(HangUp);
        writer.WriteVarUShort(MsgId);
        writer.WriteShort((short) Parameters.Count());
        foreach (string objectToSend in Parameters) writer.WriteUTF(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        HangUp = reader.ReadBoolean();
        MsgId = reader.ReadVarUShort();
        ushort parametersCount = reader.ReadUShort();
        var parameters_ = new string[parametersCount];

        for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
            parameters_[parametersIndex] = reader.ReadUTF();
        Parameters = parameters_;
    }
}