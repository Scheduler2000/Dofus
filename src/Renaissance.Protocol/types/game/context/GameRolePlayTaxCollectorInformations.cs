//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:27.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

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

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write((short)(Identification.ProtocolId));
			writer.Write(this.Identification.Serialize());
			writer.Write(this.GuildLevel);
			writer.Write(this.TaxCollectorAttack);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
reader.Skip(2); // skip read short
			this.Identification = new TaxCollectorStaticInformations();
			this.Identification.Deserialize(reader);
			this.GuildLevel = reader.Read<byte>();
			this.TaxCollectorAttack = reader.Read<int>();

		}


	}
}