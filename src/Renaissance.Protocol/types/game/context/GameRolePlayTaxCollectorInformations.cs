//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:58.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.context
{
	public class GameRolePlayTaxCollectorInformations : GameRolePlayActorInformations, IDofusType
	{
		public new const int NetworkId = 148;
		public new int ProtocolId { get { return NetworkId; } }

		public TaxCollectorStaticInformations Identification { get; set; }

		public byte GuildLevel { get; set; }

		public int TaxCollectorAttack { get; set; }


		public GameRolePlayTaxCollectorInformations() { }


		public GameRolePlayTaxCollectorInformations InitGameRolePlayTaxCollectorInformations(TaxCollectorStaticInformations _identification, byte _guildlevel, int _taxcollectorattack)
		{

			this.Identification = _identification;
			this.GuildLevel = _guildlevel;
			this.TaxCollectorAttack = _taxcollectorattack;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += 2;
			var serialized1 = this.Identification.Serialize();
			size += serialized1.Length;
			size += DofusBinaryFactory.Sizing.SizeOf(GuildLevel);
			size += DofusBinaryFactory.Sizing.SizeOf(TaxCollectorAttack);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData((short)(Identification.ProtocolId));
			writer.WriteDatas(serialized1);
			writer.WriteData(this.GuildLevel);
			writer.WriteData(this.TaxCollectorAttack);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			reader.Skip(2); // skip protocolManager.GetInstance(short)
			this.Identification = new TaxCollectorStaticInformations();
			this.Identification.Deserialize(reader);
			this.GuildLevel = reader.Read<byte>();
			this.TaxCollectorAttack = reader.Read<int>();

		}


	}
}
