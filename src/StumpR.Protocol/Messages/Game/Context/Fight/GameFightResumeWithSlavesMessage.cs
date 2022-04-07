using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightResumeWithSlavesMessage : GameFightResumeMessage
{
    public new const uint Id = 6205;

    public GameFightResumeWithSlavesMessage(IEnumerable<FightDispellableEffectExtendedInformations> effects,
        IEnumerable<GameActionMark> marks,
        ushort gameTurn,
        int fightStart,
        IEnumerable<Idol> idols,
        IEnumerable<GameFightEffectTriggerCount> fxTriggerCounts,
        IEnumerable<GameFightSpellCooldown> spellCooldowns,
        sbyte summonCount,
        sbyte bombCount,
        IEnumerable<GameFightResumeSlaveInfo> slavesInfo)
    {
        Effects = effects;
        Marks = marks;
        GameTurn = gameTurn;
        FightStart = fightStart;
        Idols = idols;
        FxTriggerCounts = fxTriggerCounts;
        SpellCooldowns = spellCooldowns;
        SummonCount = summonCount;
        BombCount = bombCount;
        SlavesInfo = slavesInfo;
    }

    public GameFightResumeWithSlavesMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GameFightResumeSlaveInfo> SlavesInfo { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) SlavesInfo.Count());
        foreach (GameFightResumeSlaveInfo objectToSend in SlavesInfo) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort slavesInfoCount = reader.ReadUShort();
        var slavesInfo_ = new GameFightResumeSlaveInfo[slavesInfoCount];

        for (var slavesInfoIndex = 0; slavesInfoIndex < slavesInfoCount; slavesInfoIndex++)
        {
            var objectToAdd = new GameFightResumeSlaveInfo();
            objectToAdd.Deserialize(reader);
            slavesInfo_[slavesInfoIndex] = objectToAdd;
        }
        SlavesInfo = slavesInfo_;
    }
}