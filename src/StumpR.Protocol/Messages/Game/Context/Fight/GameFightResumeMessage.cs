using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightResumeMessage : GameFightSpectateMessage
{
    public new const uint Id = 4566;

    public GameFightResumeMessage(IEnumerable<FightDispellableEffectExtendedInformations> effects,
        IEnumerable<GameActionMark> marks,
        ushort gameTurn,
        int fightStart,
        IEnumerable<Idol> idols,
        IEnumerable<GameFightEffectTriggerCount> fxTriggerCounts,
        IEnumerable<GameFightSpellCooldown> spellCooldowns,
        sbyte summonCount,
        sbyte bombCount)
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
    }

    public GameFightResumeMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<GameFightSpellCooldown> SpellCooldowns { get; set; }

    public sbyte SummonCount { get; set; }

    public sbyte BombCount { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort((short) SpellCooldowns.Count());
        foreach (GameFightSpellCooldown objectToSend in SpellCooldowns) objectToSend.Serialize(writer);
        writer.WriteSByte(SummonCount);
        writer.WriteSByte(BombCount);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        ushort spellCooldownsCount = reader.ReadUShort();
        var spellCooldowns_ = new GameFightSpellCooldown[spellCooldownsCount];

        for (var spellCooldownsIndex = 0; spellCooldownsIndex < spellCooldownsCount; spellCooldownsIndex++)
        {
            var objectToAdd = new GameFightSpellCooldown();
            objectToAdd.Deserialize(reader);
            spellCooldowns_[spellCooldownsIndex] = objectToAdd;
        }
        SpellCooldowns = spellCooldowns_;
        SummonCount = reader.ReadSByte();
        BombCount = reader.ReadSByte();
    }
}