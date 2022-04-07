using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameActionFightMarkCellsMessage : AbstractGameActionMessage
{
    public new const uint Id = 1180;

    public GameActionFightMarkCellsMessage(ushort actionId, double sourceId, GameActionMark mark)
    {
        ActionId = actionId;
        SourceId = sourceId;
        Mark = mark;
    }

    public GameActionFightMarkCellsMessage()
    {
    }

    public override uint MessageId => Id;

    public GameActionMark Mark { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        Mark.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Mark = new GameActionMark();
        Mark.Deserialize(reader);
    }
}