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

namespace Renaissance.Protocol.types.game.actions.fight
{
	public class FightTemporarySpellImmunityEffect : AbstractFightDispellableEffect, IDofusType
	{
		public new const int NetworkId = 366;
		public new int ProtocolId { get { return NetworkId; } }

		public int ImmuneSpellId { get; set; }


		public FightTemporarySpellImmunityEffect() { }


		public FightTemporarySpellImmunityEffect InitFightTemporarySpellImmunityEffect(int _immunespellid)
		{

			this.ImmuneSpellId = _immunespellid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.ImmuneSpellId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.ImmuneSpellId = reader.Read<int>();

		}


	}
}
