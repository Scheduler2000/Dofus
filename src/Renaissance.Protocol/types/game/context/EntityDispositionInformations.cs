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

namespace Renaissance.Protocol.types.game.context
{
	public class EntityDispositionInformations : IDofusType
	{
		public  const int NetworkId = 60;
		public  int ProtocolId { get { return NetworkId; } }

		public short CellId { get; set; }

		public byte Direction { get; set; }


		public EntityDispositionInformations() { }


		public EntityDispositionInformations InitEntityDispositionInformations(short _cellid, byte _direction)
		{

			this.CellId = _cellid;
			this.Direction = _direction;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(CellId);
			size += DofusBinaryFactory.Sizing.SizeOf(Direction);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.CellId);
			writer.WriteData(this.Direction);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.CellId = reader.Read<short>();
			this.Direction = reader.Read<byte>();

		}


	}
}
