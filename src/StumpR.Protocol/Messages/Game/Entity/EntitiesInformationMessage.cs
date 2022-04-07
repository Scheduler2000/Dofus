using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EntitiesInformationMessage : Message
{
    public const uint Id = 5147;

    public EntitiesInformationMessage(IEnumerable<EntityInformation> entities)
    {
        Entities = entities;
    }

    public EntitiesInformationMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<EntityInformation> Entities { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Entities.Count());
        foreach (EntityInformation objectToSend in Entities) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort entitiesCount = reader.ReadUShort();
        var entities_ = new EntityInformation[entitiesCount];

        for (var entitiesIndex = 0; entitiesIndex < entitiesCount; entitiesIndex++)
        {
            var objectToAdd = new EntityInformation();
            objectToAdd.Deserialize(reader);
            entities_[entitiesIndex] = objectToAdd;
        }
        Entities = entities_;
    }
}