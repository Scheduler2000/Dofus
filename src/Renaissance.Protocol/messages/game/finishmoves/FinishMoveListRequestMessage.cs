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

namespace Renaissance.Protocol.messages.game.finishmoves
{
	public class FinishMoveListRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6702;
		public  int ProtocolId { get { return NetworkId; } }


		public FinishMoveListRequestMessage() { }


		public FinishMoveListRequestMessage InitFinishMoveListRequestMessage()
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
