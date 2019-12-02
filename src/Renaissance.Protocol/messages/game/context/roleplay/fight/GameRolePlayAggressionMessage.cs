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
	public class GameRolePlayAggressionMessage : IDofusMessage
	{
		public  const int NetworkId = 6073;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> AttackerId { get; set; }

		public CustomVar<long> DefenderId { get; set; }


		public GameRolePlayAggressionMessage() { }


		public GameRolePlayAggressionMessage InitGameRolePlayAggressionMessage(CustomVar<long> _attackerid, CustomVar<long> _defenderid)
		{

			this.AttackerId = _attackerid;
			this.DefenderId = _defenderid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.AttackerId);
			writer.Write(this.DefenderId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.AttackerId = reader.Read<CustomVar<long>>();
			this.DefenderId = reader.Read<CustomVar<long>>();

		}


	}
}