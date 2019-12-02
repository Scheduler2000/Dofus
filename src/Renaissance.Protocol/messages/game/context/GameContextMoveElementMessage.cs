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
using    Renaissance.Protocol.types.game.context;

namespace Renaissance.Protocol.messages.game.context
{
	public class GameContextMoveElementMessage : IDofusMessage
	{
		public  const int NetworkId = 253;
		public  int ProtocolId { get { return NetworkId; } }

		public EntityMovementInformations Movement { get; set; }


		public GameContextMoveElementMessage() { }


		public GameContextMoveElementMessage InitGameContextMoveElementMessage(EntityMovementInformations _movement)
		{

			this.Movement = _movement;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Movement.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Movement = new EntityMovementInformations();
			this.Movement.Deserialize(reader);

		}


	}
}
