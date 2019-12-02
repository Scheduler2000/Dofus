//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:23.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.fight
{
	public class GameRolePlayAttackMonsterRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6191;
		public  int ProtocolId { get { return NetworkId; } }

		public double MonsterGroupId { get; set; }


		public GameRolePlayAttackMonsterRequestMessage() { }


		public GameRolePlayAttackMonsterRequestMessage InitGameRolePlayAttackMonsterRequestMessage(double _monstergroupid)
		{

			this.MonsterGroupId = _monstergroupid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.MonsterGroupId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MonsterGroupId = reader.Read<double>();

		}


	}
}
