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

namespace Renaissance.Protocol.messages.game.interactive.zaap
{
	public class ZaapRespawnSaveRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6572;
		public  int ProtocolId { get { return NetworkId; } }


		public ZaapRespawnSaveRequestMessage() { }


		public ZaapRespawnSaveRequestMessage InitZaapRespawnSaveRequestMessage()
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
