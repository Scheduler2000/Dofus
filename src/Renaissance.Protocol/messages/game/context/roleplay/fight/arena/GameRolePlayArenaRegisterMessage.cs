//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:57.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.fight.arena
{
	public class GameRolePlayArenaRegisterMessage : IDofusMessage
	{
		public  const int NetworkId = 6280;
		public  int ProtocolId { get { return NetworkId; } }

		public int BattleMode { get; set; }


		public GameRolePlayArenaRegisterMessage() { }


		public GameRolePlayArenaRegisterMessage InitGameRolePlayArenaRegisterMessage(int _battlemode)
		{

			this.BattleMode = _battlemode;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(BattleMode);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.BattleMode);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.BattleMode = reader.Read<int>();

		}


	}
}
