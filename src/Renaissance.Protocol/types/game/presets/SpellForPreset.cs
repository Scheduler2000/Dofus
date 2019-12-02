//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:28.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.presets
{
	public class SpellForPreset : IDofusType
	{
		public  const int NetworkId = 557;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> SpellId { get; set; }

		public short[] Shortcuts { get; set; }


		public SpellForPreset() { }


		public SpellForPreset InitSpellForPreset(CustomVar<short> _spellid, short[] _shortcuts)
		{

			this.SpellId = _spellid;
			this.Shortcuts = _shortcuts;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.SpellId);
			writer.Write((short)(this.Shortcuts.Length));
			foreach(var item in Shortcuts)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SpellId = reader.Read<CustomVar<short>>();
			int Shortcuts_length = reader.Read<short>();
			this.Shortcuts = new short[Shortcuts_length];
			for(int i = 0; i < Shortcuts_length; i++)
				this.Shortcuts[i] = reader.Read<short>();

		}


	}
}
