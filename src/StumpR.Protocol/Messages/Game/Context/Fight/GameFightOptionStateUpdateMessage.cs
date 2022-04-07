using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightOptionStateUpdateMessage : Message
{
    public const uint Id = 4608;

    public GameFightOptionStateUpdateMessage(ushort fightId, sbyte teamId, sbyte option, bool state)
    {
        FightId = fightId;
        TeamId = teamId;
        Option = option;
        State = state;
    }

    public GameFightOptionStateUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort FightId { get; set; }

    public sbyte TeamId { get; set; }

    public sbyte Option { get; set; }

    public bool State { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(FightId);
        writer.WriteSByte(TeamId);
        writer.WriteSByte(Option);
        writer.WriteBoolean(State);
    }

    public override void Deserialize(IDataReader reader)
    {
        FightId = reader.ReadVarUShort();
        TeamId = reader.ReadSByte();
        Option = reader.ReadSByte();
        State = reader.ReadBoolean();
    }
}