//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:09.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context
{
	public class GameCautiousMapMovementRequestMessage : GameMapMovementRequestMessage, IDofusMessage
	{
		public new const int NetworkId = 6496;
		public new int ProtocolId { get { return NetworkId; } }


		public GameCautiousMapMovementRequestMessage() { }


		public GameCautiousMapMovementRequestMessage InitGameCautiousMapMovementRequestMessage()
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
