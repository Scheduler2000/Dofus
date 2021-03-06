//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:47.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
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

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(SpellLevelId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.SpellLevelId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SpellLevelId = reader.Read<CustomVar<int>>();

		}


	}
}
