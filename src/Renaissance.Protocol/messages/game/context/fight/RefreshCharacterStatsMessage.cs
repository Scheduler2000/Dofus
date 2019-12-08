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
	public class RefreshCharacterStatsMessage : IDofusMessage
	{
		public  const int NetworkId = 6699;
		public  int ProtocolId { get { return NetworkId; } }

		public double FighterId { get; set; }

		public GameFightMinimalStats Stats { get; set; }


		public RefreshCharacterStatsMessage() { }


		public RefreshCharacterStatsMessage InitRefreshCharacterStatsMessage(double _fighterid, GameFightMinimalStats _stats)
		{

			this.FighterId = _fighterid;
			this.Stats = _stats;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(FighterId);
			var serialized1 = this.Stats.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.FighterId);
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.FighterId = reader.Read<double>();
			this.Stats = new GameFightMinimalStats();
			this.Stats.Deserialize(reader);

		}


	}
}
