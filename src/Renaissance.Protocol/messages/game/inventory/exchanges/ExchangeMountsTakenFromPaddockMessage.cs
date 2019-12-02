//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:20.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

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

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Name);
			writer.Write(this.WorldX);
			writer.Write(this.WorldY);
			writer.Write(this.Ownername);

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