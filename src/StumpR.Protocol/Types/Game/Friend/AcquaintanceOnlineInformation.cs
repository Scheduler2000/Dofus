using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class AcquaintanceOnlineInformation : AcquaintanceInformation
{
    public new const short Id = 4750;

    public AcquaintanceOnlineInformation(int accountId,
        AccountTagInformation accountTag,
        sbyte playerState,
        ulong playerId,
        string playerName,
        ushort moodSmileyId,
        PlayerStatus status)
    {
        AccountId = accountId;
        AccountTag = accountTag;
        PlayerState = playerState;
        PlayerId = playerId;
        PlayerName = playerName;
        MoodSmileyId = moodSmileyId;
        Status = status;
    }

    public AcquaintanceOnlineInformation()
    {
    }

    public override short TypeId => Id;

    public ulong PlayerId { get; set; }

    public string PlayerName { get; set; }

    public ushort MoodSmileyId { get; set; }

    public PlayerStatus Status { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarULong(PlayerId);
        writer.WriteUTF(PlayerName);
        writer.WriteVarUShort(MoodSmileyId);
        writer.WriteShort(Status.TypeId);
        Status.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        PlayerId = reader.ReadVarULong();
        PlayerName = reader.ReadUTF();
        MoodSmileyId = reader.ReadVarUShort();
        Status = ProtocolTypeManager.GetInstance<PlayerStatus>(reader.ReadShort());
        Status.Deserialize(reader);
    }
}