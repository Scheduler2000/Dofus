//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:42.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.actions
{
	public class GameActionNoopMessage : IDofusMessage
	{
		public  const int NetworkId = 1002;
		public  int ProtocolId { get { return NetworkId; } }


		public GameActionNoopMessage() { }


		public GameActionNoopMessage InitGameActionNoopMessage()
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
