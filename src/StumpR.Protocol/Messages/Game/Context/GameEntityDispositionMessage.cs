using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameEntityDispositionMessage : Message
{
    public const uint Id = 8701;

    public GameEntityDispositionMessage(IdentifiedEntityDispositionInformations disposition)
    {
        Disposition = disposition;
    }

    public GameEntityDispositionMessage()
    {
    }

    public override uint MessageId => Id;

    public IdentifiedEntityDispositionInformations Disposition { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Disposition.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Disposition = new IdentifiedEntityDispositionInformations();
        Disposition.Deserialize(reader);
    }
}