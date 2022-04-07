using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayShowActorMessage : Message
{
    public const uint Id = 503;

    public GameRolePlayShowActorMessage(GameRolePlayActorInformations informations)
    {
        Informations = informations;
    }

    public GameRolePlayShowActorMessage()
    {
    }

    public override uint MessageId => Id;

    public GameRolePlayActorInformations Informations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(Informations.TypeId);
        Informations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Informations = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
        Informations.Deserialize(reader);
    }
}