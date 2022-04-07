using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class GameFightSpectateMessage : Message
{
    public const uint Id = 8991;

    public GameFightSpectateMessage(IEnumerable<FightDispellableEffectExtendedInformations> effects,
        IEnumerable<GameActionMark> marks,
        ushort gameTurn,
        int fightStart,
        IEnumerable<Idol> idols,
        IEnumerable<GameFightEffectTriggerCount> fxTriggerCounts)
    {
        Effects = effects;
        Marks = marks;
        GameTurn = gameTurn;
        FightStart = fightStart;
        Idols = idols;
        FxTriggerCounts = fxTriggerCounts;
    }

    public GameFightSpectateMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<FightDispellableEffectExtendedInformations> Effects { get; set; }

    public IEnumerable<GameActionMark> Marks { get; set; }

    public ushort GameTurn { get; set; }

    public int FightStart { get; set; }

    public IEnumerable<Idol> Idols { get; set; }

    public IEnumerable<GameFightEffectTriggerCount> FxTriggerCounts { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Effects.Count());
        foreach (FightDispellableEffectExtendedInformations objectToSend in Effects) objectToSend.Serialize(writer);
        writer.WriteShort((short) Marks.Count());
        foreach (GameActionMark objectToSend in Marks) objectToSend.Serialize(writer);
        writer.WriteVarUShort(GameTurn);
        writer.WriteInt(FightStart);
        writer.WriteShort((short) Idols.Count());
        foreach (Idol objectToSend in Idols) objectToSend.Serialize(writer);
        writer.WriteShort((short) FxTriggerCounts.Count());
        foreach (GameFightEffectTriggerCount objectToSend in FxTriggerCounts) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort effectsCount = reader.ReadUShort();
        var effects_ = new FightDispellableEffectExtendedInformations[effectsCount];

        for (var effectsIndex = 0; effectsIndex < effectsCount; effectsIndex++)
        {
            var objectToAdd = new FightDispellableEffectExtendedInformations();
            objectToAdd.Deserialize(reader);
            effects_[effectsIndex] = objectToAdd;
        }
        Effects = effects_;
        ushort marksCount = reader.ReadUShort();
        var marks_ = new GameActionMark[marksCount];

        for (var marksIndex = 0; marksIndex < marksCount; marksIndex++)
        {
            var objectToAdd = new GameActionMark();
            objectToAdd.Deserialize(reader);
            marks_[marksIndex] = objectToAdd;
        }
        Marks = marks_;
        GameTurn = reader.ReadVarUShort();
        FightStart = reader.ReadInt();
        ushort idolsCount = reader.ReadUShort();
        var idols_ = new Idol[idolsCount];

        for (var idolsIndex = 0; idolsIndex < idolsCount; idolsIndex++)
        {
            var objectToAdd = new Idol();
            objectToAdd.Deserialize(reader);
            idols_[idolsIndex] = objectToAdd;
        }
        Idols = idols_;
        ushort fxTriggerCountsCount = reader.ReadUShort();
        var fxTriggerCounts_ = new GameFightEffectTriggerCount[fxTriggerCountsCount];

        for (var fxTriggerCountsIndex = 0; fxTriggerCountsIndex < fxTriggerCountsCount; fxTriggerCountsIndex++)
        {
            var objectToAdd = new GameFightEffectTriggerCount();
            objectToAdd.Deserialize(reader);
            fxTriggerCounts_[fxTriggerCountsIndex] = objectToAdd;
        }
        FxTriggerCounts = fxTriggerCounts_;
    }
}