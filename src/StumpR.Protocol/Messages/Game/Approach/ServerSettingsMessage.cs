using StumpR.Binary;

namespace StumpR.Protocol.Messages;

[Serializable]
public class ServerSettingsMessage : Message
{
    public const uint Id = 298;

    public ServerSettingsMessage(bool isMonoAccount,
        bool hasFreeAutopilot,
        string lang,
        sbyte community,
        sbyte gameType,
        ushort arenaLeaveBanTime,
        int itemMaxLevel)
    {
        IsMonoAccount = isMonoAccount;
        HasFreeAutopilot = hasFreeAutopilot;
        Lang = lang;
        Community = community;
        GameType = gameType;
        ArenaLeaveBanTime = arenaLeaveBanTime;
        ItemMaxLevel = itemMaxLevel;
    }

    public ServerSettingsMessage()
    {
    }

    public override uint MessageId => Id;

    public bool IsMonoAccount { get; set; }

    public bool HasFreeAutopilot { get; set; }

    public string Lang { get; set; }

    public sbyte Community { get; set; }

    public sbyte GameType { get; set; }

    public ushort ArenaLeaveBanTime { get; set; }

    public int ItemMaxLevel { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, IsMonoAccount);
        flag = BooleanByteWrapper.SetFlag(flag, 1, HasFreeAutopilot);
        writer.WriteByte(flag);
        writer.WriteUTF(Lang);
        writer.WriteSByte(Community);
        writer.WriteSByte(GameType);
        writer.WriteVarUShort(ArenaLeaveBanTime);
        writer.WriteInt(ItemMaxLevel);
    }

    public override void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        IsMonoAccount = BooleanByteWrapper.GetFlag(flag, 0);
        HasFreeAutopilot = BooleanByteWrapper.GetFlag(flag, 1);
        Lang = reader.ReadUTF();
        Community = reader.ReadSByte();
        GameType = reader.ReadSByte();
        ArenaLeaveBanTime = reader.ReadVarUShort();
        ItemMaxLevel = reader.ReadInt();
    }
}