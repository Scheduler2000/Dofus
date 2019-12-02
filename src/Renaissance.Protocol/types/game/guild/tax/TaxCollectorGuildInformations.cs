//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:31.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context.roleplay;

namespace Renaissance.Protocol.types.game.guild.tax
{
	public class TaxCollectorGuildInformations : TaxCollectorComplementaryInformations, IDofusType
	{
		public new const int NetworkId = 446;
		public new int ProtocolId { get { return NetworkId; } }

		public BasicGuildInformations Guild { get; set; }


		public TaxCollectorGuildInformations() { }


		public TaxCollectorGuildInformations InitTaxCollectorGuildInformations(BasicGuildInformations _guild)
		{

			this.Guild = _guild;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.Guild.Serialize());

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Guild = new BasicGuildInformations();
			this.Guild.Deserialize(reader);

		}


	}
}
