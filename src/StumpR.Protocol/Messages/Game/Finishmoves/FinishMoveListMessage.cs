using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class FinishMoveListMessage : Message
{
    public const uint Id = 596;

    public FinishMoveListMessage(IEnumerable<FinishMoveInformations> finishMoves)
    {
        FinishMoves = finishMoves;
    }

    public FinishMoveListMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<FinishMoveInformations> FinishMoves { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) FinishMoves.Count());
        foreach (FinishMoveInformations objectToSend in FinishMoves) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort finishMovesCount = reader.ReadUShort();
        var finishMoves_ = new FinishMoveInformations[finishMovesCount];

        for (var finishMovesIndex = 0; finishMovesIndex < finishMovesCount; finishMovesIndex++)
        {
            var objectToAdd = new FinishMoveInformations();
            objectToAdd.Deserialize(reader);
            finishMoves_[finishMovesIndex] = objectToAdd;
        }
        FinishMoves = finishMoves_;
    }
}