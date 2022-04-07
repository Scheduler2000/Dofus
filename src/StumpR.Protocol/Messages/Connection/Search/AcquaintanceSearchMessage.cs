using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AcquaintanceSearchMessage : Message
{
    public const uint Id = 9528;

    public AcquaintanceSearchMessage(AccountTagInformation tag)
    {
        Tag = tag;
    }

    public AcquaintanceSearchMessage()
    {
    }

    public override uint MessageId => Id;

    public AccountTagInformation Tag { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Tag.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Tag = new AccountTagInformation();
        Tag.Deserialize(reader);
    }
}