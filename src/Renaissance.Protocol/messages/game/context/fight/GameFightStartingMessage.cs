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

namespace Renaissance.Protocol.messages.game.context.fight
{
	public class GameFightStartingMessage : IDofusMessage
	{
		public  const int NetworkId = 700;
		public  int ProtocolId { get { return NetworkId; } }

		public byte FightType { get; set; }

		public CustomVar<short> FightId { get; set; }

		public double AttackerId { get; set; }

		public double DefenderId { get; set; }


		public GameFightStartingMessage() { }


		public GameFightStartingMessage InitGameFightStartingMessage(byte _fighttype, CustomVar<short> _fightid, double _attackerid, double _defenderid)
		{

			this.FightType = _fighttype;
			this.FightId = _fightid;
			this.AttackerId = _attackerid;
			this.DefenderId = _defenderid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(FightType);
			size += DofusBinaryFactory.Sizing.SizeOf(FightId);
			size += DofusBinaryFactory.Sizing.SizeOf(AttackerId);
			size += DofusBinaryFactory.Sizing.SizeOf(DefenderId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.FightType);
			writer.WriteData(this.FightId);
			writer.WriteData(this.AttackerId);
			writer.WriteData(this.DefenderId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.FightType = reader.Read<byte>();
			this.FightId = reader.Read<CustomVar<short>>();
			this.AttackerId = reader.Read<double>();
			this.DefenderId = reader.Read<double>();

		}


	}
}
