//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:29.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.fight
{
	public class FightResultFighterListEntry : FightResultListEntry, IDofusType
	{
		public new const int NetworkId = 189;
		public new int ProtocolId { get { return NetworkId; } }

		public double Id { get; set; }

		public bool Alive { get; set; }


		public FightResultFighterListEntry() { }


		public FightResultFighterListEntry InitFightResultFighterListEntry(double _id, bool _alive)
		{

			this.Id = _id;
			this.Alive = _alive;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Id);
			writer.Write(this.Alive);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Id = reader.Read<double>();
			this.Alive = reader.Read<bool>();

		}


	}
}
