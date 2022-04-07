using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapComplementaryInformationsDataMessage : Message
{
    public const uint Id = 1182;

    public MapComplementaryInformationsDataMessage(ushort subAreaId,
        double mapId,
        IEnumerable<HouseInformations> houses,
        IEnumerable<GameRolePlayActorInformations> actors,
        IEnumerable<InteractiveElement> interactiveElements,
        IEnumerable<StatedElement> statedElements,
        IEnumerable<MapObstacle> obstacles,
        IEnumerable<FightCommonInformations> fights,
        bool hasAggressiveMonsters,
        FightStartingPositions fightStartPositions)
    {
        SubAreaId = subAreaId;
        MapId = mapId;
        Houses = houses;
        Actors = actors;
        InteractiveElements = interactiveElements;
        StatedElements = statedElements;
        Obstacles = obstacles;
        Fights = fights;
        HasAggressiveMonsters = hasAggressiveMonsters;
        FightStartPositions = fightStartPositions;
    }

    public MapComplementaryInformationsDataMessage()
    {
    }

    public override uint MessageId => Id;

    public ushort SubAreaId { get; set; }

    public double MapId { get; set; }

    public IEnumerable<HouseInformations> Houses { get; set; }

    public IEnumerable<GameRolePlayActorInformations> Actors { get; set; }

    public IEnumerable<InteractiveElement> InteractiveElements { get; set; }

    public IEnumerable<StatedElement> StatedElements { get; set; }

    public IEnumerable<MapObstacle> Obstacles { get; set; }

    public IEnumerable<FightCommonInformations> Fights { get; set; }

    public bool HasAggressiveMonsters { get; set; }

    public FightStartingPositions FightStartPositions { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteVarUShort(SubAreaId);
        writer.WriteDouble(MapId);
        writer.WriteShort((short) Houses.Count());

        foreach (HouseInformations objectToSend in Houses)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) Actors.Count());

        foreach (GameRolePlayActorInformations objectToSend in Actors)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) InteractiveElements.Count());

        foreach (InteractiveElement objectToSend in InteractiveElements)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
        writer.WriteShort((short) StatedElements.Count());
        foreach (StatedElement objectToSend in StatedElements) objectToSend.Serialize(writer);
        writer.WriteShort((short) Obstacles.Count());
        foreach (MapObstacle objectToSend in Obstacles) objectToSend.Serialize(writer);
        writer.WriteShort((short) Fights.Count());
        foreach (FightCommonInformations objectToSend in Fights) objectToSend.Serialize(writer);
        writer.WriteBoolean(HasAggressiveMonsters);
        FightStartPositions.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        SubAreaId = reader.ReadVarUShort();
        MapId = reader.ReadDouble();
        ushort housesCount = reader.ReadUShort();
        var houses_ = new HouseInformations[housesCount];

        for (var housesIndex = 0; housesIndex < housesCount; housesIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<HouseInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            houses_[housesIndex] = objectToAdd;
        }
        Houses = houses_;
        ushort actorsCount = reader.ReadUShort();
        var actors_ = new GameRolePlayActorInformations[actorsCount];

        for (var actorsIndex = 0; actorsIndex < actorsCount; actorsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            actors_[actorsIndex] = objectToAdd;
        }
        Actors = actors_;
        ushort interactiveElementsCount = reader.ReadUShort();
        var interactiveElements_ = new InteractiveElement[interactiveElementsCount];

        for (var interactiveElementsIndex = 0; interactiveElementsIndex < interactiveElementsCount; interactiveElementsIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<InteractiveElement>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            interactiveElements_[interactiveElementsIndex] = objectToAdd;
        }
        InteractiveElements = interactiveElements_;
        ushort statedElementsCount = reader.ReadUShort();
        var statedElements_ = new StatedElement[statedElementsCount];

        for (var statedElementsIndex = 0; statedElementsIndex < statedElementsCount; statedElementsIndex++)
        {
            var objectToAdd = new StatedElement();
            objectToAdd.Deserialize(reader);
            statedElements_[statedElementsIndex] = objectToAdd;
        }
        StatedElements = statedElements_;
        ushort obstaclesCount = reader.ReadUShort();
        var obstacles_ = new MapObstacle[obstaclesCount];

        for (var obstaclesIndex = 0; obstaclesIndex < obstaclesCount; obstaclesIndex++)
        {
            var objectToAdd = new MapObstacle();
            objectToAdd.Deserialize(reader);
            obstacles_[obstaclesIndex] = objectToAdd;
        }
        Obstacles = obstacles_;
        ushort fightsCount = reader.ReadUShort();
        var fights_ = new FightCommonInformations[fightsCount];

        for (var fightsIndex = 0; fightsIndex < fightsCount; fightsIndex++)
        {
            var objectToAdd = new FightCommonInformations();
            objectToAdd.Deserialize(reader);
            fights_[fightsIndex] = objectToAdd;
        }
        Fights = fights_;
        HasAggressiveMonsters = reader.ReadBoolean();
        FightStartPositions = new FightStartingPositions();
        FightStartPositions.Deserialize(reader);
    }
}