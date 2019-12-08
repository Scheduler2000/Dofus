//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:51.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeMountsTakenFromPaddockMessage : IDofusMessage
	{
		public  const int NetworkId = 6554;
		public  int ProtocolId { get { return NetworkId; } }

		public string Name { get; set; }

		public short WorldX { get; set; }

		public short WorldY { get; set; }

		public string Ownername { get; set; }


		public ExchangeMountsTakenFromPaddockMessage() { }


		public ExchangeMountsTakenFromPaddockMessage InitExchangeMountsTakenFromPaddockMessage(string _name, short _worldx, short _worldy, string _ownername)
		{

			this.Name = _name;
			this.WorldX = _worldx;
			this.WorldY = _worldy;
			this.Ownername = _ownername;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Name);
			size += DofusBinaryFactory.Sizing.SizeOf(WorldX);
			size += DofusBinaryFactory.Sizing.SizeOf(WorldY);
			size += DofusBinaryFactory.Sizing.SizeOf(Ownername);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Name);
			writer.WriteData(this.WorldX);
			writer.WriteData(this.WorldY);
			writer.WriteData(this.Ownername);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Name = reader.Read<string>();
			this.WorldX = reader.Read<short>();
			this.WorldY = reader.Read<short>();
			this.Ownername = reader.Read<string>();

		}


	}
}
