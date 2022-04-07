using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameContextActorPositionInformations
{
    public const short Id = 1244;

    public GameContextActorPositionInformations(double contextualId, EntityDispositionInformations disposition)
    {
        ContextualId = contextualId;
        Disposition = disposition;
    }

    public GameContextActorPositionInformations()
    {
    }

    public virtual short TypeId => Id;

    public double ContextualId { get; set; }

    public EntityDispositionInformations Disposition { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(ContextualId);
        writer.WriteShort(Disposition.TypeId);
        Disposition.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ContextualId = reader.ReadDouble();
        Disposition = ProtocolTypeManager.GetInstance<EntityDispositionInformations>(reader.ReadShort());
        Disposition.Deserialize(reader);
    }
}