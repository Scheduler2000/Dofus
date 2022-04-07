using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameEntitiesDispositionMessage : Message
{
    public const uint Id = 853;

    public GameEntitiesDispositionMessage(IEnumerable<IdentifiedEntityDispositionInformations> dispositions)
    {
        Dispositions = dispositions;
    }

    public GameEntitiesDispositionMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<IdentifiedEntityDispositionInformations> Dispositions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Dispositions.Count());
        foreach (IdentifiedEntityDispositionInformations objectToSend in Dispositions) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort dispositionsCount = reader.ReadUShort();
        var dispositions_ = new IdentifiedEntityDispositionInformations[dispositionsCount];

        for (var dispositionsIndex = 0; dispositionsIndex < dispositionsCount; dispositionsIndex++)
        {
            var objectToAdd = new IdentifiedEntityDispositionInformations();
            objectToAdd.Deserialize(reader);
            dispositions_[dispositionsIndex] = objectToAdd;
        }
        Dispositions = dispositions_;
    }
}