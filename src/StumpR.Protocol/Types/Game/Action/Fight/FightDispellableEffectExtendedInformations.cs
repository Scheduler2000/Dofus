using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class FightDispellableEffectExtendedInformations
{
    public const short Id = 8005;

    public FightDispellableEffectExtendedInformations(ushort actionId, double sourceId, AbstractFightDispellableEffect effect)
    {
        ActionId = actionId;
        SourceId = sourceId;
        Effect = effect;
    }

    public FightDispellableEffectExtendedInformations()
    {
    }

    public virtual short TypeId => Id;

    public ushort ActionId { get; set; }

    public double SourceId { get; set; }

    public AbstractFightDispellableEffect Effect { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(ActionId);
        writer.WriteDouble(SourceId);
        writer.WriteShort(Effect.TypeId);
        Effect.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        ActionId = reader.ReadVarUShort();
        SourceId = reader.ReadDouble();
        Effect = ProtocolTypeManager.GetInstance<AbstractFightDispellableEffect>(reader.ReadShort());
        Effect.Deserialize(reader);
    }
}