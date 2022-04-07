using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SetCharacterRestrictionsMessage : Message
{
    public const uint Id = 7853;

    public SetCharacterRestrictionsMessage(double actorId, ActorRestrictionsInformations restrictions)
    {
        ActorId = actorId;
        Restrictions = restrictions;
    }

    public SetCharacterRestrictionsMessage()
    {
    }

    public override uint MessageId => Id;

    public double ActorId { get; set; }

    public ActorRestrictionsInformations Restrictions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(ActorId);
        Restrictions.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ActorId = reader.ReadDouble();
        Restrictions = new ActorRestrictionsInformations();
        Restrictions.Deserialize(reader);
    }
}