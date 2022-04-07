using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EntityTalkMessage : Message
{
    public const uint Id = 4321;

    public EntityTalkMessage(double entityId, ushort textId, IEnumerable<string> parameters)
    {
        EntityId = entityId;
        TextId = textId;
        Parameters = parameters;
    }

    public EntityTalkMessage()
    {
    }

    public override uint MessageId => Id;

    public double EntityId { get; set; }

    public ushort TextId { get; set; }

    public IEnumerable<string> Parameters { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(EntityId);
        writer.WriteVarUShort(TextId);
        writer.WriteShort((short) Parameters.Count());
        foreach (string objectToSend in Parameters) writer.WriteUTF(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        EntityId = reader.ReadDouble();
        TextId = reader.ReadVarUShort();
        ushort parametersCount = reader.ReadUShort();
        var parameters_ = new string[parametersCount];

        for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
            parameters_[parametersIndex] = reader.ReadUTF();
        Parameters = parameters_;
    }
}