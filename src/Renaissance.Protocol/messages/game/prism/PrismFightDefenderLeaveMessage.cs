//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:13.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

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

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.SubAreaId);
			writer.Write(this.FightId);
			writer.Write(this.FighterToRemoveId);

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