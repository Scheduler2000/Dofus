//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:28.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay;

namespace Renaissance.Protocol.types.game.paddock
{
	public class PaddockGuildedInformations : PaddockBuyableInformations, IDofusType
	{
		public new const int NetworkId = 508;
		public new int ProtocolId { get { return NetworkId; } }

		public bool Deserted { get; set; }

		public GuildInformations GuildInfo { get; set; }


		public PaddockGuildedInformations() { }


		public PaddockGuildedInformations InitPaddockGuildedInformations(bool _deserted, GuildInformations _guildinfo)
		{

			this.Deserted = _deserted;
			this.GuildInfo = _guildinfo;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Deserted);
			writer.Write(this.GuildInfo.Serialize());

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Deserted = reader.Read<bool>();
			this.GuildInfo = new GuildInformations();
			this.GuildInfo.Deserialize(reader);

		}


	}
}