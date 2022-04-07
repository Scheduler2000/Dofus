using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AlignmentWarEffortProgressionMessage : Message
{
    public const uint Id = 2084;

    public AlignmentWarEffortProgressionMessage(IEnumerable<AlignmentWarEffortInformation> effortProgressions)
    {
        EffortProgressions = effortProgressions;
    }

    public AlignmentWarEffortProgressionMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<AlignmentWarEffortInformation> EffortProgressions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) EffortProgressions.Count());
        foreach (AlignmentWarEffortInformation objectToSend in EffortProgressions) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort effortProgressionsCount = reader.ReadUShort();
        var effortProgressions_ = new AlignmentWarEffortInformation[effortProgressionsCount];

        for (var effortProgressionsIndex = 0; effortProgressionsIndex < effortProgressionsCount; effortProgressionsIndex++)
        {
            var objectToAdd = new AlignmentWarEffortInformation();
            objectToAdd.Deserialize(reader);
            effortProgressions_[effortProgressionsIndex] = objectToAdd;
        }
        EffortProgressions = effortProgressions_;
    }
}