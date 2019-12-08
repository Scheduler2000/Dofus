//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:00.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class GameRolePlayMutantInformations : GameRolePlayHumanoidInformations, IDofusType
	{
		public new const int NetworkId = 3;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> MonsterId { get; set; }

		public byte PowerLevel { get; set; }


		public GameRolePlayMutantInformations() { }


		public GameRolePlayMutantInformations InitGameRolePlayMutantInformations(HumanInformations _humanoidinfo, int _accountid, CustomVar<short> _monsterid, byte _powerlevel)
		{

			base.HumanoidInfo = _humanoidinfo;
			base.AccountId = _accountid;
			this.MonsterId = _monsterid;
			this.PowerLevel = _powerlevel;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(MonsterId);
			size += DofusBinaryFactory.Sizing.SizeOf(PowerLevel);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.MonsterId);
			writer.WriteData(this.PowerLevel);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.MonsterId = reader.Read<CustomVar<short>>();
			this.PowerLevel = reader.Read<byte>();

		}


	}
}
