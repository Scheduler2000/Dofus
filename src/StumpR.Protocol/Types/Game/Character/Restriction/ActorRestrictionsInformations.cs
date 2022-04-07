using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class ActorRestrictionsInformations
{
    public const short Id = 8982;

    public ActorRestrictionsInformations(bool cantBeAggressed,
        bool cantBeChallenged,
        bool cantTrade,
        bool cantBeAttackedByMutant,
        bool cantRun,
        bool forceSlowWalk,
        bool cantMinimize,
        bool cantMove,
        bool cantAggress,
        bool cantChallenge,
        bool cantExchange,
        bool cantAttack,
        bool cantChat,
        bool cantBeMerchant,
        bool cantUseObject,
        bool cantUseTaxCollector,
        bool cantUseInteractive,
        bool cantSpeakToNPC,
        bool cantChangeZone,
        bool cantAttackMonster)
    {
        CantBeAggressed = cantBeAggressed;
        CantBeChallenged = cantBeChallenged;
        CantTrade = cantTrade;
        CantBeAttackedByMutant = cantBeAttackedByMutant;
        CantRun = cantRun;
        ForceSlowWalk = forceSlowWalk;
        CantMinimize = cantMinimize;
        CantMove = cantMove;
        CantAggress = cantAggress;
        CantChallenge = cantChallenge;
        CantExchange = cantExchange;
        CantAttack = cantAttack;
        CantChat = cantChat;
        CantBeMerchant = cantBeMerchant;
        CantUseObject = cantUseObject;
        CantUseTaxCollector = cantUseTaxCollector;
        CantUseInteractive = cantUseInteractive;
        CantSpeakToNPC = cantSpeakToNPC;
        CantChangeZone = cantChangeZone;
        CantAttackMonster = cantAttackMonster;
    }

    public ActorRestrictionsInformations()
    {
    }

    public virtual short TypeId => Id;

    public bool CantBeAggressed { get; set; }

    public bool CantBeChallenged { get; set; }

    public bool CantTrade { get; set; }

    public bool CantBeAttackedByMutant { get; set; }

    public bool CantRun { get; set; }

    public bool ForceSlowWalk { get; set; }

    public bool CantMinimize { get; set; }

    public bool CantMove { get; set; }

    public bool CantAggress { get; set; }

    public bool CantChallenge { get; set; }

    public bool CantExchange { get; set; }

    public bool CantAttack { get; set; }

    public bool CantChat { get; set; }

    public bool CantBeMerchant { get; set; }

    public bool CantUseObject { get; set; }

    public bool CantUseTaxCollector { get; set; }

    public bool CantUseInteractive { get; set; }

    public bool CantSpeakToNPC { get; set; }

    public bool CantChangeZone { get; set; }

    public bool CantAttackMonster { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        var flag = new byte();
        flag = BooleanByteWrapper.SetFlag(flag, 0, CantBeAggressed);
        flag = BooleanByteWrapper.SetFlag(flag, 1, CantBeChallenged);
        flag = BooleanByteWrapper.SetFlag(flag, 2, CantTrade);
        flag = BooleanByteWrapper.SetFlag(flag, 3, CantBeAttackedByMutant);
        flag = BooleanByteWrapper.SetFlag(flag, 4, CantRun);
        flag = BooleanByteWrapper.SetFlag(flag, 5, ForceSlowWalk);
        flag = BooleanByteWrapper.SetFlag(flag, 6, CantMinimize);
        flag = BooleanByteWrapper.SetFlag(flag, 7, CantMove);
        writer.WriteByte(flag);
        flag = BooleanByteWrapper.SetFlag(flag, 0, CantAggress);
        flag = BooleanByteWrapper.SetFlag(flag, 1, CantChallenge);
        flag = BooleanByteWrapper.SetFlag(flag, 2, CantExchange);
        flag = BooleanByteWrapper.SetFlag(flag, 3, CantAttack);
        flag = BooleanByteWrapper.SetFlag(flag, 4, CantChat);
        flag = BooleanByteWrapper.SetFlag(flag, 5, CantBeMerchant);
        flag = BooleanByteWrapper.SetFlag(flag, 6, CantUseObject);
        flag = BooleanByteWrapper.SetFlag(flag, 7, CantUseTaxCollector);
        writer.WriteByte(flag);
        flag = BooleanByteWrapper.SetFlag(flag, 0, CantUseInteractive);
        flag = BooleanByteWrapper.SetFlag(flag, 1, CantSpeakToNPC);
        flag = BooleanByteWrapper.SetFlag(flag, 2, CantChangeZone);
        flag = BooleanByteWrapper.SetFlag(flag, 3, CantAttackMonster);
        writer.WriteByte(flag);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        byte flag = reader.ReadByte();
        CantBeAggressed = BooleanByteWrapper.GetFlag(flag, 0);
        CantBeChallenged = BooleanByteWrapper.GetFlag(flag, 1);
        CantTrade = BooleanByteWrapper.GetFlag(flag, 2);
        CantBeAttackedByMutant = BooleanByteWrapper.GetFlag(flag, 3);
        CantRun = BooleanByteWrapper.GetFlag(flag, 4);
        ForceSlowWalk = BooleanByteWrapper.GetFlag(flag, 5);
        CantMinimize = BooleanByteWrapper.GetFlag(flag, 6);
        CantMove = BooleanByteWrapper.GetFlag(flag, 7);
        flag = reader.ReadByte();
        CantAggress = BooleanByteWrapper.GetFlag(flag, 0);
        CantChallenge = BooleanByteWrapper.GetFlag(flag, 1);
        CantExchange = BooleanByteWrapper.GetFlag(flag, 2);
        CantAttack = BooleanByteWrapper.GetFlag(flag, 3);
        CantChat = BooleanByteWrapper.GetFlag(flag, 4);
        CantBeMerchant = BooleanByteWrapper.GetFlag(flag, 5);
        CantUseObject = BooleanByteWrapper.GetFlag(flag, 6);
        CantUseTaxCollector = BooleanByteWrapper.GetFlag(flag, 7);
        flag = reader.ReadByte();
        CantUseInteractive = BooleanByteWrapper.GetFlag(flag, 0);
        CantSpeakToNPC = BooleanByteWrapper.GetFlag(flag, 1);
        CantChangeZone = BooleanByteWrapper.GetFlag(flag, 2);
        CantAttackMonster = BooleanByteWrapper.GetFlag(flag, 3);
    }
}