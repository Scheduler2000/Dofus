//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:56.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.spell
{
	public class SpellVariantActivationRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6707;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> SpellId { get; set; }


		public SpellVariantActivationRequestMessage() { }


		public SpellVariantActivationRequestMessage InitSpellVariantActivationRequestMessage(CustomVar<short> _spellid)
		{

			this.SpellId = _spellid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(SpellId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.SpellId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SpellId = reader.Read<CustomVar<short>>();

		}


	}
}
