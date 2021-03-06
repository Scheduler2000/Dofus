//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:46.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.prism
{
	public class PrismFightDefenderLeaveMessage : IDofusMessage
	{
		public  const int NetworkId = 5892;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> SubAreaId { get; set; }

		public CustomVar<short> FightId { get; set; }

		public CustomVar<long> FighterToRemoveId { get; set; }


		public PrismFightDefenderLeaveMessage() { }


		public PrismFightDefenderLeaveMessage InitPrismFightDefenderLeaveMessage(CustomVar<short> _subareaid, CustomVar<short> _fightid, CustomVar<long> _fightertoremoveid)
		{

			this.SubAreaId = _subareaid;
			this.FightId = _fightid;
			this.FighterToRemoveId = _fightertoremoveid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(SubAreaId);
			size += DofusBinaryFactory.Sizing.SizeOf(FightId);
			size += DofusBinaryFactory.Sizing.SizeOf(FighterToRemoveId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.SubAreaId);
			writer.WriteData(this.FightId);
			writer.WriteData(this.FighterToRemoveId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SubAreaId = reader.Read<CustomVar<short>>();
			this.FightId = reader.Read<CustomVar<short>>();
			this.FighterToRemoveId = reader.Read<CustomVar<long>>();

		}


	}
}
