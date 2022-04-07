using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class NotificationByServerMessage : Message
{
    public const uint Id = 2613;

    public NotificationByServerMessage(ushort objectId, IEnumerable<string> parameters, bool forceOpen)
    {
        ObjectId = objectId;
        Parameters = parameters;
        ForceOpen = forceOpen;
    }

    public NotificationByServerMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort ObjectId { get; set; }

    public IEnumerable<string> Parameters { get; set; }

    public bool ForceOpen { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ObjectId);
        writer.WriteShort((short) Parameters.Count());
        foreach (string objectToSend in Parameters) writer.WriteUTF(objectToSend);
        writer.WriteBoolean(ForceOpen);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadVarUShort();
        ushort parametersCount = reader.ReadUShort();
        var parameters_ = new string[parametersCount];

        for (var parametersIndex = 0; parametersIndex < parametersCount; parametersIndex++)
            parameters_[parametersIndex] = reader.ReadUTF();
        Parameters = parameters_;
        ForceOpen = reader.ReadBoolean();
    }
}