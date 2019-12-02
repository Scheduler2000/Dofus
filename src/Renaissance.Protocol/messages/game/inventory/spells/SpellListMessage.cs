//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:22.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.data.items;

namespace Renaissance.Protocol.messages.game.inventory.spells
{
	public class SpellListMessage : IDofusMessage
	{
		public  const int NetworkId = 1200;
		public  int ProtocolId { get { return NetworkId; } }

		public bool SpellPrevisualization { get; set; }

		public SpellItem[] Spells { get; set; }


		public SpellListMessage() { }


		public SpellListMessage InitSpellListMessage(bool _spellprevisualization, SpellItem[] _spells)
		{

			this.SpellPrevisualization = _spellprevisualization;
			this.Spells = _spells;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.SpellPrevisualization);
			writer.Write((short)(this.Spells.Length));
			foreach(var obj in Spells)
			{
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SpellPrevisualization = reader.Read<bool>();
			int Spells_length = reader.Read<short>();
			this.Spells = new SpellItem[Spells_length];
			for(int i = 0; i < Spells_length; i++)
			{
				this.Spells[i] = new SpellItem();
				this.Spells[i].Deserialize(reader);
			}

		}


	}
}
