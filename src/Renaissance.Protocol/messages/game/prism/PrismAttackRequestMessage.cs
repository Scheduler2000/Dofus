//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:13.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.prism
{
	public class PrismAttackRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6042;
		public  int ProtocolId { get { return NetworkId; } }


		public PrismAttackRequestMessage() { }


		public PrismAttackRequestMessage InitPrismAttackRequestMessage()
		{


			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();


			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{


		}


	}
}