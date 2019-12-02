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
	public class ExchangeCraftResultMessage : IDofusMessage
	{
		public  const int NetworkId = 5790;
		public  int ProtocolId { get { return NetworkId; } }

		public byte CraftResult { get; set; }


		public ExchangeCraftResultMessage() { }


		public ExchangeCraftResultMessage InitExchangeCraftResultMessage(byte _craftresult)
		{

			this.CraftResult = _craftresult;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.CraftResult);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.CraftResult = reader.Read<byte>();

		}


	}
}