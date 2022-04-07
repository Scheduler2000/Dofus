using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ExchangeCraftResultMagicWithObjectDescMessage : ExchangeCraftResultWithObjectDescMessage
{
    public new const uint Id = 6242;

    public ExchangeCraftResultMagicWithObjectDescMessage(sbyte craftResult, ObjectItemNotInContainer objectInfo, sbyte magicPoolStatus)
    {
        CraftResult = craftResult;
        ObjectInfo = objectInfo;
        MagicPoolStatus = magicPoolStatus;
    }

    public ExchangeCraftResultMagicWithObjectDescMessage()
    {
    }

    public override uint MessageId => Id;

    public sbyte MagicPoolStatus { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteSByte(MagicPoolStatus);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        MagicPoolStatus = reader.ReadSByte();
    }
}