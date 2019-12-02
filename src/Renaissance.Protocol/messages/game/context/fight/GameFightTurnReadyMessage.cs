//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:18.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.fight
{
	public class GameFightTurnReadyMessage : IDofusMessage
	{
		public  const int NetworkId = 716;
		public  int ProtocolId { get { return NetworkId; } }

		public bool IsReady { get; set; }


		public GameFightTurnReadyMessage() { }


		public GameFightTurnReadyMessage InitGameFightTurnReadyMessage(bool _isready)
		{

			this.IsReady = _isready;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.IsReady);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.IsReady = reader.Read<bool>();

		}


	}
}