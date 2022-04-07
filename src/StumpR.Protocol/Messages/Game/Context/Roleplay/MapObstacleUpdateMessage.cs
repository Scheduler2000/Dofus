using StumpR.Binary;
using StumpR.Protocol.Types;

namespace StumpR.Protocol.Messages;

[Serializable]
public class MapObstacleUpdateMessage : Message
{
    public const uint Id = 9984;

    public MapObstacleUpdateMessage(IEnumerable<MapObstacle> obstacles)
    {
        Obstacles = obstacles;
    }

    public MapObstacleUpdateMessage()
    {
    }

    public override uint MessageId => Id;

    public IEnumerable<MapObstacle> Obstacles { get; set; }

    public override void Serialize(IDataWriter writer)
    {
        writer.WriteShort((short) Obstacles.Count());
        foreach (MapObstacle objectToSend in Obstacles) objectToSend.Serialize(writer);
    }

    public override void Deserialize(IDataReader reader)
    {
        ushort obstaclesCount = reader.ReadUShort();
        var obstacles_ = new MapObstacle[obstaclesCount];

        for (var obstaclesIndex = 0; obstaclesIndex < obstaclesCount; obstaclesIndex++)
        {
            var objectToAdd = new MapObstacle();
            objectToAdd.Deserialize(reader);
            obstacles_[obstaclesIndex] = objectToAdd;
        }
        Obstacles = obstacles_;
    }
}