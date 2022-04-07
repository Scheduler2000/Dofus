using StumpR.Binary;

namespace StumpR.Protocol.Types;

[Serializable]
public class GameContextBasicSpawnInformation
{
    public const short Id = 2015;

    public GameContextBasicSpawnInformation(sbyte teamId, bool alive, GameContextActorPositionInformations informations)
    {
        TeamId = teamId;
        Alive = alive;
        Informations = informations;
    }

    public GameContextBasicSpawnInformation()
    {
    }

    public virtual short TypeId => Id;

    public sbyte TeamId { get; set; }

    public bool Alive { get; set; }

    public GameContextActorPositionInformations Informations { get; set; }

    public virtual void Serialize(IDataWriter writer)
    {
        writer.WriteSByte(TeamId);
        writer.WriteBoolean(Alive);
        writer.WriteShort(Informations.TypeId);
        Informations.Serialize(writer);
    }

    public virtual void Deserialize(IDataReader reader)
    {
        TeamId = reader.ReadSByte();
        Alive = reader.ReadBoolean();
        Informations = ProtocolTypeManager.GetInstance<GameContextActorPositionInformations>(reader.ReadShort());
        Informations.Deserialize(reader);
    }
}