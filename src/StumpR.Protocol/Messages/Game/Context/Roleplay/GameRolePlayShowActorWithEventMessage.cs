using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayShowActorWithEventMessage : GameRolePlayShowActorMessage
{
    public new const uint Id = 2684;

    public GameRolePlayShowActorWithEventMessage(GameRolePlayActorInformations informations, sbyte actorEventId)
    {
        Informations = informations;
        ActorEventId = actorEventId;
    }

    public GameRolePlayShowActorWithEventMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte ActorEventId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(ActorEventId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ActorEventId = reader.ReadSByte();
    }
}