using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapComplementaryInformationsWithCoordsMessage : MapComplementaryInformationsDataMessage
{
    public new const uint Id = 5440;

    public MapComplementaryInformationsWithCoordsMessage(ushort subAreaId,
        double mapId,
        IEnumerable<HouseInformations> houses,
        IEnumerable<GameRolePlayActorInformations> actors,
        IEnumerable<InteractiveElement> interactiveElements,
        IEnumerable<StatedElement> statedElements,
        IEnumerable<MapObstacle> obstacles,
        IEnumerable<FightCommonInformations> fights,
        bool hasAggressiveMonsters,
        FightStartingPositions fightStartPositions,
        short worldX,
        short worldY)
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
        WorldX = worldX;
        WorldY = worldY;
    }

    public MapComplementaryInformationsWithCoordsMessage()
    {
    }

    public override uint MessageId => Id;

    public short WorldX { get; set; }

    public short WorldY { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteShort(WorldX);
        writer.WriteShort(WorldY);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        WorldX = reader.ReadShort();
        WorldY = reader.ReadShort();
    }
}