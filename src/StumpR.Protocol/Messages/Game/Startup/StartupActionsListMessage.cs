using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class StartupActionsListMessage : Message
{
    public const uint Id = 798;

    public StartupActionsListMessage(IEnumerable<StartupActionAddObject> actions)
    {
        Actions = actions;
    }

    public StartupActionsListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<StartupActionAddObject> Actions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Actions.Count());
        foreach (StartupActionAddObject objectToSend in Actions) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort actionsCount = reader.ReadUShort();
        var actions_ = new StartupActionAddObject[actionsCount];

        for (var actionsIndex = 0; actionsIndex < actionsCount; actionsIndex++)
        {
            var objectToAdd = new StartupActionAddObject();
            objectToAdd.Deserialize(reader);
            actions_[actionsIndex] = objectToAdd;
        }
        Actions = actions_;
    }
}