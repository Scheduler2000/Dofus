//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:44.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context
{
	public class GameMapNoMovementMessage : IDofusMessage
	{
		public  const int NetworkId = 954;
		public  int ProtocolId { get { return NetworkId; } }

		public short CellX { get; set; }

		public short CellY { get; set; }


		public GameMapNoMovementMessage() { }


		public GameMapNoMovementMessage InitGameMapNoMovementMessage(short _cellx, short _celly)
		{

			this.CellX = _cellx;
			this.CellY = _celly;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(CellX);
			size += DofusBinaryFactory.Sizing.SizeOf(CellY);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.CellX);
			writer.WriteData(this.CellY);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.CellX = reader.Read<short>();
			this.CellY = reader.Read<short>();

		}


	}
}
