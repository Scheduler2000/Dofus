using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameContextRefreshEntityLookMessage : Message
{
    public const uint Id = 5261;

    public GameContextRefreshEntityLookMessage(double objectId, EntityLook look)
    {
        ObjectId = objectId;
        Look = look;
    }

    public GameContextRefreshEntityLookMessage()
    {
    }

    public override uint MessageId => Id;

    public double ObjectId { get; set; }

    public EntityLook Look { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteDouble(ObjectId);
        Look.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ObjectId = reader.ReadDouble();
        Look = new EntityLook();
        Look.Deserialize(reader);
    }
}