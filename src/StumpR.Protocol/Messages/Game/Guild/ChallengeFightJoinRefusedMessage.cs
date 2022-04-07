using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ChallengeFightJoinRefusedMessage : Message
{
    public const uint Id = 2066;

    public ChallengeFightJoinRefusedMessage(ulong playerId, sbyte reason)
    {
        PlayerId = playerId;
        Reason = reason;
    }

    public ChallengeFightJoinRefusedMessage()
    {
    }

    public override uint MessageId => Id;

    public ulong PlayerId { get; set; }

    public sbyte Reason { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarULong(PlayerId);
        writer.WriteSByte(Reason);
    }

    public override void Deserialize(IDataReader reader)
    {
        PlayerId = reader.ReadVarULong();
        Reason = reader.ReadSByte();
    }
}