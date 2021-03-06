//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:59.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.actions.fight
{
	public class GameActionMarkedCell : IDofusType
	{
		public  const int NetworkId = 85;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> CellId { get; set; }

		public byte ZoneSize { get; set; }

		public int CellColor { get; set; }

		public byte CellsType { get; set; }


		public GameActionMarkedCell() { }


		public GameActionMarkedCell InitGameActionMarkedCell(CustomVar<short> _cellid, byte _zonesize, int _cellcolor, byte _cellstype)
		{

			this.CellId = _cellid;
			this.ZoneSize = _zonesize;
			this.CellColor = _cellcolor;
			this.CellsType = _cellstype;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(CellId);
			size += DofusBinaryFactory.Sizing.SizeOf(ZoneSize);
			size += DofusBinaryFactory.Sizing.SizeOf(CellColor);
			size += DofusBinaryFactory.Sizing.SizeOf(CellsType);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.CellId);
			writer.WriteData(this.ZoneSize);
			writer.WriteData(this.CellColor);
			writer.WriteData(this.CellsType);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.CellId = reader.Read<CustomVar<short>>();
			this.ZoneSize = reader.Read<byte>();
			this.CellColor = reader.Read<int>();
			this.CellsType = reader.Read<byte>();

		}


	}
}
