//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:54.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
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

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(MonsterGroupId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.MonsterGroupId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MonsterGroupId = reader.Read<double>();

		}


	}
}
