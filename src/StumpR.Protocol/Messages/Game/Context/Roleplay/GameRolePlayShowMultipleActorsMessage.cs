using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayShowMultipleActorsMessage : Message
{
    public const uint Id = 1377;

    public GameRolePlayShowMultipleActorsMessage(IEnumerable<GameRolePlayActorInformations> informationsList)
    {
        InformationsList = informationsList;
    }

    public GameRolePlayShowMultipleActorsMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GameRolePlayActorInformations> InformationsList { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) InformationsList.Count());

        foreach (GameRolePlayActorInformations objectToSend in InformationsList)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort informationsListCount = reader.ReadUShort();
        var informationsList_ = new GameRolePlayActorInformations[informationsListCount];

        for (var informationsListIndex = 0; informationsListIndex < informationsListCount; informationsListIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            informationsList_[informationsListIndex] = objectToAdd;
        }
        InformationsList = informationsList_;
    }
}