//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:17.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.fight
{
	public class GameFightPlacementSwapPositionsErrorMessage : IDofusMessage
	{
		public  const int NetworkId = 6548;
		public  int ProtocolId { get { return NetworkId; } }


		public GameFightPlacementSwapPositionsErrorMessage() { }


		public GameFightPlacementSwapPositionsErrorMessage InitGameFightPlacementSwapPositionsErrorMessage()
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