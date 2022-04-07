using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class EntityInformationMessage : Message
{
    public const uint Id = 7474;

    public EntityInformationMessage(EntityInformation entity)
    {
        Entity = entity;
    }

    public EntityInformationMessage()
    {
    }

    public override uint MessageId => Id;

    public EntityInformation Entity { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Entity.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Entity = new EntityInformation();
        Entity.Deserialize(reader);
    }
}