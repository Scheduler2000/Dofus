using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapComplementaryInformationsBreachMessage : MapComplementaryInformationsDataMessage
{
    public new const uint Id = 6429;

    public MapComplementaryInformationsBreachMessage(ushort subAreaId,
        double mapId,
        IEnumerable<HouseInformations> houses,
        IEnumerable<GameRolePlayActorInformations> actors,
        IEnumerable<InteractiveElement> interactiveElements,
        IEnumerable<StatedElement> statedElements,
        IEnumerable<MapObstacle> obstacles,
        IEnumerable<FightCommonInformations> fights,
        bool hasAggressiveMonsters,
        FightStartingPositions fightStartPositions,
        uint floor,
        sbyte room,
        short infinityMode,
        IEnumerable<BreachBranch> branches)
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
        Floor = floor;
        Room = room;
        InfinityMode = infinityMode;
        Branches = branches;
    }

    public MapComplementaryInformationsBreachMessage()
    {
    }

    public override uint MessageId => Id;

    public uint Floor { get; set; }

    public sbyte Room { get; set; }

    public short InfinityMode { get; set; }

    public IEnumerable<BreachBranch> Branches { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        base.Serialize(writer);
        writer.WriteVarUInt(Floor);
        writer.WriteSByte(Room);
        writer.WriteShort(InfinityMode);
        writer.WriteShort((short) Branches.Count());

        foreach (BreachBranch objectToSend in Branches)
        {
            writer.WriteShort(objectToSend.TypeId);
            objectToSend.Serialize(writer);
        }
    }

    public override void Deserialize(IDataReader reader)
    {
        base.Deserialize(reader);
        Floor = reader.ReadVarUInt();
        Room = reader.ReadSByte();
        InfinityMode = reader.ReadShort();
        ushort branchesCount = reader.ReadUShort();
        var branches_ = new BreachBranch[branchesCount];

        for (var branchesIndex = 0; branchesIndex < branchesCount; branchesIndex++)
        {
            var objectToAdd = ProtocolTypeManager.GetInstance<BreachBranch>(reader.ReadShort());
            objectToAdd.Deserialize(reader);
            branches_[branchesIndex] = objectToAdd;
        }
        Branches = branches_;
    }
}