using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapComplementaryInformationsDataInHouseMessage : MapComplementaryInformationsDataMessage
{
    public new const uint Id = 2024;

    public MapComplementaryInformationsDataInHouseMessage(ushort subAreaId,
        double mapId,
        IEnumerable<HouseInformations> houses,
        IEnumerable<GameRolePlayActorInformations> actors,
        IEnumerable<InteractiveElement> interactiveElements,
        IEnumerable<StatedElement> statedElements,
        IEnumerable<MapObstacle> obstacles,
        IEnumerable<FightCommonInformations> fights,
        bool hasAggressiveMonsters,
        FightStartingPositions fightStartPositions,
        HouseInformationsInside currentHouse)
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
        CurrentHouse = currentHouse;
    }

    public MapComplementaryInformationsDataInHouseMessage()
    {
    }

    public override uint MessageId => Id;

    public HouseInformationsInside CurrentHouse { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        CurrentHouse.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        CurrentHouse = new HouseInformationsInside();
        CurrentHouse.Deserialize(reader);
    }
}