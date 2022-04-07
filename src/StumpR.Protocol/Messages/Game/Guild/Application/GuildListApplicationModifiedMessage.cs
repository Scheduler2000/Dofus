using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GuildListApplicationModifiedMessage : Message
{
    public const uint Id = 8105;

    public GuildListApplicationModifiedMessage(GuildApplicationInformation apply, sbyte state, ulong playerId)
    {
        Apply = apply;
        State = state;
        PlayerId = playerId;
    }

    public GuildListApplicationModifiedMessage()
    {
    }

    public override uint MessageId => Id;

    public GuildApplicationInformation Apply { get; set; }

    public sbyte State { get; set; }

    public ulong PlayerId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        Apply.Serialize(writer);
        writer.WriteSByte(State);
        writer.WriteVarULong(PlayerId);
    }

    public override void Deserialize(IDataReader reader)
    {
        Apply = new GuildApplicationInformation();
        Apply.Deserialize(reader);
        State = reader.ReadSByte();
        PlayerId = reader.ReadVarULong();
    }
}