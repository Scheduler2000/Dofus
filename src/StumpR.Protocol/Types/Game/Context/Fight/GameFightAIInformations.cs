using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameFightAIInformations : GameFightFighterInformations
{
    public new const short Id = 858;

    public GameFightAIInformations(double contextualId,
        EntityDispositionInformations disposition,
        EntityLook look,
        GameContextBasicSpawnInformation spawnInfo,
        sbyte wave,
        GameFightCharacteristics stats,
        IEnumerable<ushort> previousPositions)
    {
        ContextualId = contextualId;
        Disposition = disposition;
        Look = look;
        SpawnInfo = spawnInfo;
        Wave = wave;
        Stats = stats;
        PreviousPositions = previousPositions;
    }

    public GameFightAIInformations()
    {
    }

    public override short TypeId => Id;

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
    }
}