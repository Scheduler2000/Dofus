using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapComplementaryInformationsDataInHavenBagMessage : MapComplementaryInformationsDataMessage
{
    public new const uint Id = 3738;

    public MapComplementaryInformationsDataInHavenBagMessage(ushort subAreaId,
        double mapId,
        IEnumerable<HouseInformations> houses,
        IEnumerable<GameRolePlayActorInformations> actors,
        IEnumerable<InteractiveElement> interactiveElements,
        IEnumerable<StatedElement> statedElements,
        IEnumerable<MapObstacle> obstacles,
        IEnumerable<FightCommonInformations> fights,
        bool hasAggressiveMonsters,
        FightStartingPositions fightStartPositions,
        CharacterMinimalInformations ownerInformations,
        sbyte theme,
        sbyte roomId,
        sbyte maxRoomId)
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
        OwnerInformations = ownerInformations;
        Theme = theme;
        RoomId = roomId;
        MaxRoomId = maxRoomId;
    }

    public MapComplementaryInformationsDataInHavenBagMessage()
    {
    }

    public override uint MessageId => Id;

    public CharacterMinimalInformations OwnerInformations { get; set; }

    public sbyte Theme { get; set; }

    public sbyte RoomId { get; set; }

    public sbyte MaxRoomId { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        OwnerInformations.Serialize(writer);
        writer.WriteSByte(Theme);
        writer.WriteSByte(RoomId);
        writer.WriteSByte(MaxRoomId);
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        OwnerInformations = new CharacterMinimalInformations();
        OwnerInformations.Deserialize(reader);
        Theme = reader.ReadSByte();
        RoomId = reader.ReadSByte();
        MaxRoomId = reader.ReadSByte();
    }
}