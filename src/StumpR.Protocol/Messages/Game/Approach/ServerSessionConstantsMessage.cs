using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ServerSessionConstantsMessage : Message
{
    public const uint Id = 646;

    public ServerSessionConstantsMessage(IEnumerable<ServerSessionConstant> variables)
    {
        Variables = variables;
    }

    public ServerSessionConstantsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<ServerSessionConstant> Variables { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Variables.Count());

        foreach (ServerSessionConstant objectToSend in Variables)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort variablesCount = reader.ReadUShort();
        var variables_ = new ServerSessionConstant[variablesCount];

        for (var variablesIndex = 0; variablesIndex < variablesCount; variablesIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<ServerSessionConstant>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            variables_[variablesIndex] = objectToAdd;
        }
        Variables = variables_;
    }
}