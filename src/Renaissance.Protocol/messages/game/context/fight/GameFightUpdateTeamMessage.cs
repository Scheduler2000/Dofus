//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:49.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.fight;

namespace Renaissance.Protocol.messages.game.context.fight
{
	public class GameFightUpdateTeamMessage : IDofusMessage
	{
		public  const int NetworkId = 5572;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> FightId { get; set; }

		public FightTeamInformations Team { get; set; }


		public GameFightUpdateTeamMessage() { }


		public GameFightUpdateTeamMessage InitGameFightUpdateTeamMessage(CustomVar<short> _fightid, FightTeamInformations _team)
		{

			this.FightId = _fightid;
			this.Team = _team;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(FightId);
			var serialized1 = this.Team.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.FightId);
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.FightId = reader.Read<CustomVar<short>>();
			this.Team = new FightTeamInformations();
			this.Team.Deserialize(reader);

		}


	}
}
