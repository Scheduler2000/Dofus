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
	public class ExchangeAcceptMessage : IDofusMessage
	{
		public  const int NetworkId = 5508;
		public  int ProtocolId { get { return NetworkId; } }


		public ExchangeAcceptMessage() { }


		public ExchangeAcceptMessage InitExchangeAcceptMessage()
		{


			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;



			using DofusWriter writer = new DofusWriter(size);


			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{


		}


	}
}
