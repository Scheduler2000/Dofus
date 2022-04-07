using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameRolePlayArenaPlayerBehavioursMessage : Message
{
    public const uint Id = 92;

    public GameRolePlayArenaPlayerBehavioursMessage(IEnumerable<string> flags, IEnumerable<string> sanctions, int banDuration)
    {
        Flags = flags;
        Sanctions = sanctions;
        BanDuration = banDuration;
    }

    public GameRolePlayArenaPlayerBehavioursMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<string> Flags { get; set; }

    public IEnumerable<string> Sanctions { get; set; }

    public int BanDuration { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Flags.Count());
        foreach (string objectToSend in Flags) writer.WriteUTF(objectToSend);
        writer.WriteShort((short) Sanctions.Count());
        foreach (string objectToSend in Sanctions) writer.WriteUTF(objectToSend);
        writer.WriteInt(BanDuration);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort flagsCount = reader.ReadUShort();
        var flags_ = new string[flagsCount];
        for (var flagsIndex = 0; flagsIndex < flagsCount; flagsIndex++) flags_[flagsIndex] = reader.ReadUTF();
        Flags = flags_;
        ushort sanctionsCount = reader.ReadUShort();
        var sanctions_ = new string[sanctionsCount];
        for (var sanctionsIndex = 0; sanctionsIndex < sanctionsCount; sanctionsIndex++) sanctions_[sanctionsIndex] = reader.ReadUTF();
        Sanctions = sanctions_;
        BanDuration = reader.ReadInt();
    }
}