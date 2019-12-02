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
	public class GameActionFightNoSpellCastMessage : IDofusMessage
	{
		public  const int NetworkId = 6132;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> SpellLevelId { get; set; }


		public GameActionFightNoSpellCastMessage() { }


		public GameActionFightNoSpellCastMessage InitGameActionFightNoSpellCastMessage(CustomVar<int> _spelllevelid)
		{

			this.SpellLevelId = _spelllevelid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.SpellLevelId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SpellLevelId = reader.Read<CustomVar<int>>();

		}


	}
}