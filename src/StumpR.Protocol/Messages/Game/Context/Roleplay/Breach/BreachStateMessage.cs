using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachStateMessage : Message
{
    public const uint Id = 5776;

    public BreachStateMessage(CharacterMinimalInformations owner, IEnumerable<ObjectEffectInteger> bonuses, uint bugdet, bool saved)
    {
        Owner = owner;
        Bonuses = bonuses;
        Bugdet = bugdet;
        Saved = saved;
    }

    public BreachStateMessage()
    {
    }

    public override uint MessageId => Id;

    public CharacterMinimalInformations Owner { get; set; }

    public IEnumerable<ObjectEffectInteger> Bonuses { get; set; }

    public uint Bugdet { get; set; }

    public bool Saved { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Owner.Serialize(writer);
        writer.WriteShort((short) Bonuses.Count());
        foreach (ObjectEffectInteger objectToSend in Bonuses) objectToSend.Serialize(writer);
        writer.WriteVarUInt(Bugdet);
        writer.WriteBoolean(Saved);
    }

    public override void Deserialize(IDataReader reader)
    {
        Owner = new CharacterMinimalInformations();
        Owner.Deserialize(reader);
        ushort bonusesCount = reader.ReadUShort();
        var bonuses_ = new ObjectEffectInteger[bonusesCount];

        for (var bonusesIndex = 0; bonusesIndex < bonusesCount; bonusesIndex++)
        {
            var objectToAdd = new ObjectEffectInteger();
            objectToAdd.Deserialize(reader);
            bonuses_[bonusesIndex] = objectToAdd;
        }
        Bonuses = bonuses_;
        Bugdet = reader.ReadVarUInt();
        Saved = reader.ReadBoolean();
    }
}