using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class PrismFightAddedMessage : Message
{
    public const uint Id = 5778;

    public PrismFightAddedMessage(PrismFightersInformation fight)
    {
        Fight = fight;
    }

    public PrismFightAddedMessage()
    {
    }

    public override uint MessageId => Id;

    public PrismFightersInformation Fight { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Fight.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Fight = new PrismFightersInformation();
        Fight.Deserialize(reader);
    }
}