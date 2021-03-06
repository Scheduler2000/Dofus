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
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.character.choice
{
	public class CharacterHardcoreOrEpicInformations : CharacterBaseInformations, IDofusType
	{
		public new const int NetworkId = 474;
		public new int ProtocolId { get { return NetworkId; } }

		public byte DeathState { get; set; }

		public CustomVar<short> DeathCount { get; set; }

		public CustomVar<short> DeathMaxLevel { get; set; }


		public CharacterHardcoreOrEpicInformations() { }


		public CharacterHardcoreOrEpicInformations InitCharacterHardcoreOrEpicInformations(bool _sex, EntityLook _entitylook, byte _breed, CustomVar<short> _level, string _name, CustomVar<long> _id, byte _deathstate, CustomVar<short> _deathcount, CustomVar<short> _deathmaxlevel)
		{

			base.Sex = _sex;
			base.EntityLook = _entitylook;
			base.Breed = _breed;
			base.Level = _level;
			base.Name = _name;
			base.Id = _id;
			this.DeathState = _deathstate;
			this.DeathCount = _deathcount;
			this.DeathMaxLevel = _deathmaxlevel;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(DeathState);
			size += DofusBinaryFactory.Sizing.SizeOf(DeathCount);
			size += DofusBinaryFactory.Sizing.SizeOf(DeathMaxLevel);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.DeathState);
			writer.WriteData(this.DeathCount);
			writer.WriteData(this.DeathMaxLevel);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.DeathState = reader.Read<byte>();
			this.DeathCount = reader.Read<CustomVar<short>>();
			this.DeathMaxLevel = reader.Read<CustomVar<short>>();

		}


	}
}
