//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:27.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay.fight.arena;

namespace Renaissance.Protocol.messages.game.context.roleplay.fight.arena
{
	public class GameRolePlayArenaUpdatePlayerInfosMessage : IDofusMessage
	{
		public  const int NetworkId = 6301;
		public  int ProtocolId { get { return NetworkId; } }

		public ArenaRankInfos Solo { get; set; }


		public GameRolePlayArenaUpdatePlayerInfosMessage() { }


		public GameRolePlayArenaUpdatePlayerInfosMessage InitGameRolePlayArenaUpdatePlayerInfosMessage(ArenaRankInfos _solo)
		{

			this.Solo = _solo;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Solo.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Solo = new ArenaRankInfos();
			this.Solo.Deserialize(reader);

		}


	}
}
