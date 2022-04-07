using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class BreachBonusMessage : Message
{
    public const uint Id = 1689;

    public BreachBonusMessage(ObjectEffectInteger bonus)
    {
        Bonus = bonus;
    }

    public BreachBonusMessage()
    {
    }

    public override uint MessageId => Id;

    public ObjectEffectInteger Bonus { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Bonus.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Bonus = new ObjectEffectInteger();
        Bonus.Deserialize(reader);
    }
}