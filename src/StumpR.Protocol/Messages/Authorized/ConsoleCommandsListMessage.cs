using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ConsoleCommandsListMessage : Message
{
    public const uint Id = 5611;

    public ConsoleCommandsListMessage(IEnumerable<string> aliases, IEnumerable<string> args, IEnumerable<string> descriptions)
    {
        Aliases = aliases;
        Args = args;
        Descriptions = descriptions;
    }

    public ConsoleCommandsListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<string> Aliases { get; set; }

    public IEnumerable<string> Args { get; set; }

    public IEnumerable<string> Descriptions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Aliases.Count());
        foreach (string objectToSend in Aliases) writer.WriteUTF(objectToSend);
        writer.WriteShort((short) Args.Count());
        foreach (string objectToSend in Args) writer.WriteUTF(objectToSend);
        writer.WriteShort((short) Descriptions.Count());
        foreach (string objectToSend in Descriptions) writer.WriteUTF(objectToSend);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort aliasesCount = reader.ReadUShort();
        var aliases_ = new string[aliasesCount];
        for (var aliasesIndex = 0; aliasesIndex < aliasesCount; aliasesIndex++) aliases_[aliasesIndex] = reader.ReadUTF();
        Aliases = aliases_;
        ushort argsCount = reader.ReadUShort();
        var args_ = new string[argsCount];
        for (var argsIndex = 0; argsIndex < argsCount; argsIndex++) args_[argsIndex] = reader.ReadUTF();
        Args = args_;
        ushort descriptionsCount = reader.ReadUShort();
        var descriptions_ = new string[descriptionsCount];

        for (var descriptionsIndex = 0; descriptionsIndex < descriptionsCount; descriptionsIndex++)
            descriptions_[descriptionsIndex] = reader.ReadUTF();
        Descriptions = descriptions_;
    }
}