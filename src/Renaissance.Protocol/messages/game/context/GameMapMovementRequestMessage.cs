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
	public class GameMapMovementRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 950;
		public  int ProtocolId { get { return NetworkId; } }

		public short[] KeyMovements { get; set; }

		public double MapId { get; set; }


		public GameMapMovementRequestMessage() { }


		public GameMapMovementRequestMessage InitGameMapMovementRequestMessage(short[] _keymovements, double _mapid)
		{

			this.KeyMovements = _keymovements;
			this.MapId = _mapid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.KeyMovements.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(KeyMovements);
			size += DofusBinaryFactory.Sizing.SizeOf(MapId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.KeyMovements.Length));
			writer.WriteDatas(KeyMovements);
			writer.WriteData(this.MapId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int KeyMovements_length = reader.Read<short>();
			this.KeyMovements = new short[KeyMovements_length];
			for(int i = 0; i < KeyMovements_length; i++)
				this.KeyMovements[i] = reader.Read<short>();
			this.MapId = reader.Read<double>();

		}


	}
}
