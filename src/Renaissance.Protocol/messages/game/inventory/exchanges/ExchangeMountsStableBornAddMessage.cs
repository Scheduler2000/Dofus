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
using    Renaissance.Protocol.types.game.mount;

namespace Renaissance.Protocol.messages.game.inventory.exchanges
{
	public class ExchangeMountsStableBornAddMessage : ExchangeMountsStableAddMessage, IDofusMessage
	{
		public new const int NetworkId = 6557;
		public new int ProtocolId { get { return NetworkId; } }


		public ExchangeMountsStableBornAddMessage() { }


		public ExchangeMountsStableBornAddMessage InitExchangeMountsStableBornAddMessage()
		{


			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);

		}


	}
}