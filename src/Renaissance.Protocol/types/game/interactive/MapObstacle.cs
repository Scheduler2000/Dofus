//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:58.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.interactive
{
	public class MapObstacle : IDofusType
	{
		public  const int NetworkId = 200;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> ObstacleCellId { get; set; }

		public byte State { get; set; }


		public MapObstacle() { }


		public MapObstacle InitMapObstacle(CustomVar<short> _obstaclecellid, byte _state)
		{

			this.ObstacleCellId = _obstaclecellid;
			this.State = _state;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ObstacleCellId);
			size += DofusBinaryFactory.Sizing.SizeOf(State);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.ObstacleCellId);
			writer.WriteData(this.State);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ObstacleCellId = reader.Read<CustomVar<short>>();
			this.State = reader.Read<byte>();

		}


	}
}
