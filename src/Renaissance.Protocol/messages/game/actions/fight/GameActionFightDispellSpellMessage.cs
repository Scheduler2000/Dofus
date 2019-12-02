//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:15.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.actions.fight
{
	public class GameActionFightDispellSpellMessage : GameActionFightDispellMessage, IDofusMessage
	{
		public new const int NetworkId = 6176;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> SpellId { get; set; }


		public GameActionFightDispellSpellMessage() { }


		public GameActionFightDispellSpellMessage InitGameActionFightDispellSpellMessage(CustomVar<short> _spellid)
		{

			this.SpellId = _spellid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.SpellId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.SpellId = reader.Read<CustomVar<short>>();

		}


	}
}