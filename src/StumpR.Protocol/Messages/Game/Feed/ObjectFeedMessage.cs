using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ObjectFeedMessage : Message
{
    public const uint Id = 5845;

    public ObjectFeedMessage(uint objectUID, IEnumerable<ObjectItemQuantity> meal)
    {
        ObjectUID = objectUID;
        Meal = meal;
    }

    public ObjectFeedMessage()
    {
    }

    public override uint MessageId => Id;

    public uint ObjectUID { get; set; }

    public IEnumerable<ObjectItemQuantity> Meal { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(ObjectUID);
        writer.WriteShort((short) Meal.Count());
        foreach (ObjectItemQuantity objectToSend in Meal) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectUID = reader.ReadVarUInt();
        ushort mealCount = reader.ReadUShort();
        var meal_ = new ObjectItemQuantity[mealCount];

        for (var mealIndex = 0; mealIndex < mealCount; mealIndex++)
        {
            var objectToAdd = new ObjectItemQuantity();
            objectToAdd.Deserialize(reader);
            meal_[mealIndex] = objectToAdd;
        }
        Meal = meal_;
    }
}