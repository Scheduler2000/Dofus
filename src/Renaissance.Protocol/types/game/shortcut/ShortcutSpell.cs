//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:59.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.shortcut
{
	public class ShortcutSpell : Shortcut, IDofusType
	{
		public new const int NetworkId = 368;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> SpellId { get; set; }


		public ShortcutSpell() { }


		public ShortcutSpell InitShortcutSpell(byte _slot, CustomVar<short> _spellid)
		{

			base.Slot = _slot;
			this.SpellId = _spellid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(SpellId);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.SpellId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.SpellId = reader.Read<CustomVar<short>>();

		}


	}
}
