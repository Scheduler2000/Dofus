using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class SpouseInformationsMessage : Message
{
    public const uint Id = 8493;

    public SpouseInformationsMessage(FriendSpouseInformations spouse)
    {
        Spouse = spouse;
    }

    public SpouseInformationsMessage()
    {
    }

    public override uint MessageId => Id;

    public FriendSpouseInformations Spouse { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort(Spouse.TypeId);
        Spouse.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        Spouse = ProtocolTypeManager.GetInstance<FriendSpouseInformations>(reader.ReadShort());
        Spouse.Deserialize(reader);
    }
}