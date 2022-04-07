using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightShowFighterMessage : Message
{
    public const uint Id = 2781;

    public GameFightShowFighterMessage(GameFightFighterInformations informations)
    {
        Informations = informations;
    }

    public GameFightShowFighterMessage()
    {
    }

    public override uint MessageId => Id;

    public GameFightFighterInformations Informations { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(Informations.TypeId);
        Informations.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Informations = ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadShort());
        Informations.Deserialize(reader);
    }
}