using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class LivingObjectMessageRequestMessage : Message
{
    public const uint Id = 3223;

    public LivingObjectMessageRequestMessage(ushort msgId, IEnumerable<string> parameters, uint livingObject)
    {
        MsgId = msgId;
        Parameters = parameters;
        LivingObject = livingObject;
    }

    public LivingObjectMessageRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort MsgId { get; set; }

    public IEnumerable<string> Parameters { get; set; }

    public uint LivingObject { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(MsgId);
        writer.WriteShort((short) Parameters.Count());
        foreach (string objectToSend in Parameters) writer.WriteUTF(objectToSend);
        writer.WriteVarUInt(LivingObject);
    }

    public override void Deserialize(IDataReader reader)
    {
        MsgId = reader.ReadVarUShort();
        ushort parametersCount = reader.ReadUShort();
        var parameters_ = new string[parametersCount];

        for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
            parameters_[parametersIndex] = reader.ReadUTF();
        Parameters = parameters_;
        LivingObject = reader.ReadVarUInt();
    }
}