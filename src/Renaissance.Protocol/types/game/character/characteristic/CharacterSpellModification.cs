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

namespace Renaissance.Protocol.types.game.character.characteristic
{
	public class CharacterSpellModification : IDofusType
	{
		public  const int NetworkId = 215;
		public  int ProtocolId { get { return NetworkId; } }

		public byte ModificationType { get; set; }

		public CustomVar<short> SpellId { get; set; }

		public CharacterBaseCharacteristic Value { get; set; }


		public CharacterSpellModification() { }


		public CharacterSpellModification InitCharacterSpellModification(byte _modificationtype, CustomVar<short> _spellid, CharacterBaseCharacteristic _value)
		{

			this.ModificationType = _modificationtype;
			this.SpellId = _spellid;
			this.Value = _value;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.ModificationType);
			writer.Write(this.SpellId);
			writer.Write(this.Value.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ModificationType = reader.Read<byte>();
			this.SpellId = reader.Read<CustomVar<short>>();
			this.Value = new CharacterBaseCharacteristic();
			this.Value.Deserialize(reader);

		}


	}
}
