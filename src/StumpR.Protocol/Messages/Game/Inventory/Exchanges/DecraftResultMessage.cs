using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class DecraftResultMessage : Message
{
    public const uint Id = 7257;

    public DecraftResultMessage(IEnumerable<DecraftedItemStackInfo> results)
    {
        Results = results;
    }

    public DecraftResultMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<DecraftedItemStackInfo> Results { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Results.Count());
        foreach (DecraftedItemStackInfo objectToSend in Results) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort resultsCount = reader.ReadUShort();
        var results_ = new DecraftedItemStackInfo[resultsCount];

        for (var resultsIndex = 0; resultsIndex < resultsCount; resultsIndex++)
        {
            var objectToAdd = new DecraftedItemStackInfo();
            objectToAdd.Deserialize(reader);
            results_[resultsIndex] = objectToAdd;
        }
        Results = results_;
    }
}