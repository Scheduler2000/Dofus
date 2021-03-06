//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:02.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.data.items.effects
{
	public class ObjectEffectCreature : ObjectEffect, IDofusType
	{
		public new const int NetworkId = 71;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> MonsterFamilyId { get; set; }


		public ObjectEffectCreature() { }


		public ObjectEffectCreature InitObjectEffectCreature(CustomVar<short> _actionid, CustomVar<short> _monsterfamilyid)
		{

			base.ActionId = _actionid;
			this.MonsterFamilyId = _monsterfamilyid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(MonsterFamilyId);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.MonsterFamilyId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.MonsterFamilyId = reader.Read<CustomVar<short>>();

		}


	}
}
