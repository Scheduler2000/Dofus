//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:50.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.interactive;

namespace Renaissance.Protocol.messages.game.context.roleplay
{
	public class MapObstacleUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 6051;
		public  int ProtocolId { get { return NetworkId; } }

		public MapObstacle[] Obstacles { get; set; }


		public MapObstacleUpdateMessage() { }


		public MapObstacleUpdateMessage InitMapObstacleUpdateMessage(MapObstacle[] _obstacles)
		{

			this.Obstacles = _obstacles;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Obstacles.Length));
			var memory1 = new Memory<byte>[Obstacles.Length];
			for(int i = 0; i < Obstacles.Length; i++)
			{
				memory1[i] = this.Obstacles[i].Serialize();
				size += memory1[i].Length;
			}


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Obstacles.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Obstacles_length = reader.Read<short>();
			this.Obstacles = new MapObstacle[Obstacles_length];
			for(int i = 0; i < Obstacles_length; i++)
			{
				this.Obstacles[i] = new MapObstacle();
				this.Obstacles[i].Deserialize(reader);
			}

		}


	}
}
