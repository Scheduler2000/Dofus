//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:26.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.fight.arena
{
	public class GameRolePlayArenaRegistrationStatusMessage : IDofusMessage
	{
		public  const int NetworkId = 6284;
		public  int ProtocolId { get { return NetworkId; } }

		public bool Registered { get; set; }

		public byte Step { get; set; }

		public int BattleMode { get; set; }


		public GameRolePlayArenaRegistrationStatusMessage() { }


		public GameRolePlayArenaRegistrationStatusMessage InitGameRolePlayArenaRegistrationStatusMessage(bool _registered, byte _step, int _battlemode)
		{

			this.Registered = _registered;
			this.Step = _step;
			this.BattleMode = _battlemode;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Registered);
			writer.Write(this.Step);
			writer.Write(this.BattleMode);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Registered = reader.Read<bool>();
			this.Step = reader.Read<byte>();
			this.BattleMode = reader.Read<int>();

		}


	}
}
