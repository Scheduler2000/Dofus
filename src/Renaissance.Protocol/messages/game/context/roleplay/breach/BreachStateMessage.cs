//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:53.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.character;
using    Renaissance.Protocol.types.game.data.items.effects;

namespace Renaissance.Protocol.messages.game.context.roleplay.breach
{
	public class BreachStateMessage : IDofusMessage
	{
		public  const int NetworkId = 6799;
		public  int ProtocolId { get { return NetworkId; } }

		public CharacterMinimalInformations Owner { get; set; }

		public ObjectEffectInteger[] Bonuses { get; set; }

		public CustomVar<int> Bugdet { get; set; }

		public bool Saved { get; set; }


		public BreachStateMessage() { }


		public BreachStateMessage InitBreachStateMessage(CharacterMinimalInformations _owner, ObjectEffectInteger[] _bonuses, CustomVar<int> _bugdet, bool _saved)
		{

			this.Owner = _owner;
			this.Bonuses = _bonuses;
			this.Bugdet = _bugdet;
			this.Saved = _saved;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.Owner.Serialize();
			size += serialized1.Length;
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Bonuses.Length));
			var memory1 = new Memory<byte>[Bonuses.Length];
			for(int i = 0; i < Bonuses.Length; i++)
			{
				memory1[i] = this.Bonuses[i].Serialize();
				size += memory1[i].Length;
			}
			size += DofusBinaryFactory.Sizing.SizeOf(Bugdet);
			size += DofusBinaryFactory.Sizing.SizeOf(Saved);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(serialized1);
			writer.WriteData((short)(this.Bonuses.Length));
			for(int i = 0; i < memory1.Length; i++)
			{
				writer.WriteDatas(memory1[i]);
			}
			writer.WriteData(this.Bugdet);
			writer.WriteData(this.Saved);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Owner = new CharacterMinimalInformations();
			this.Owner.Deserialize(reader);
			int Bonuses_length = reader.Read<short>();
			this.Bonuses = new ObjectEffectInteger[Bonuses_length];
			for(int i = 0; i < Bonuses_length; i++)
			{
				this.Bonuses[i] = new ObjectEffectInteger();
				this.Bonuses[i].Deserialize(reader);
			}
			this.Bugdet = reader.Read<CustomVar<int>>();
			this.Saved = reader.Read<bool>();

		}


	}
}
