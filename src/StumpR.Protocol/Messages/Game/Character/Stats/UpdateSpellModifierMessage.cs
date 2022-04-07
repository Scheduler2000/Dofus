using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class UpdateSpellModifierMessage : Message
{
    public const uint Id = 1672;

    public UpdateSpellModifierMessage(double actorId, CharacterSpellModification spellModifier)
    {
        ActorId = actorId;
        SpellModifier = spellModifier;
    }

    public UpdateSpellModifierMessage()
    {
    }

    public override uint MessageId => Id;

    public double ActorId { get; set; }

    public CharacterSpellModification SpellModifier { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(ActorId);
        SpellModifier.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ActorId = reader.ReadDouble();
        SpellModifier = new CharacterSpellModification();
        SpellModifier.Deserialize(reader);
    }
}