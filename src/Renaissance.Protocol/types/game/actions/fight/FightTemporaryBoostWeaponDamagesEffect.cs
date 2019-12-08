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

namespace Renaissance.Protocol.types.game.actions.fight
{
	public class FightTemporaryBoostWeaponDamagesEffect : FightTemporaryBoostEffect, IDofusType
	{
		public new const int NetworkId = 211;
		public new int ProtocolId { get { return NetworkId; } }

		public short WeaponTypeId { get; set; }


		public FightTemporaryBoostWeaponDamagesEffect() { }


		public FightTemporaryBoostWeaponDamagesEffect InitFightTemporaryBoostWeaponDamagesEffect(short _delta, CustomVar<int> _uid, double _targetid, short _turnduration, byte _dispelable, CustomVar<short> _spellid, CustomVar<int> _effectid, CustomVar<int> _parentboostuid, short _weapontypeid)
		{

			base.Delta = _delta;
			base.Uid = _uid;
			base.TargetId = _targetid;
			base.TurnDuration = _turnduration;
			base.Dispelable = _dispelable;
			base.SpellId = _spellid;
			base.EffectId = _effectid;
			base.ParentBoostUid = _parentboostuid;
			this.WeaponTypeId = _weapontypeid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(WeaponTypeId);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.WeaponTypeId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.WeaponTypeId = reader.Read<short>();

		}


	}
}
