using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameContextMoveElementMessage : Message
{
    public const uint Id = 5628;

    public GameContextMoveElementMessage(EntityMovementInformations movement)
    {
        Movement = movement;
    }

    public GameContextMoveElementMessage()
    {
    }

    public override uint MessageId => Id;

    public EntityMovementInformations Movement { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Movement.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Movement = new EntityMovementInformations();
        Movement.Deserialize(reader);
    }
}