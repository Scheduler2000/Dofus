using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class AllianceKickRequestMessage : Message
{
    public const uint Id = 1648;

    public AllianceKickRequestMessage(uint kickedId)
    {
        KickedId = kickedId;
    }

    public AllianceKickRequestMessage()
    {
    }

    public override uint MessageId => Id;

    public uint KickedId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUInt(KickedId);
    }

    public override void Deserialize(IDataReader reader)
    {
        KickedId = reader.ReadVarUInt();
    }
}