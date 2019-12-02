//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:19.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.guild.tax;

namespace Renaissance.Protocol.messages.game.guild.tax
{
	public class TaxCollectorMovementAddMessage : IDofusMessage
	{
		public  const int NetworkId = 5917;
		public  int ProtocolId { get { return NetworkId; } }

		public TaxCollectorInformations Informations { get; set; }


		public TaxCollectorMovementAddMessage() { }


		public TaxCollectorMovementAddMessage InitTaxCollectorMovementAddMessage(TaxCollectorInformations _informations)
		{

			this.Informations = _informations;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(Informations.ProtocolId));
			writer.Write(this.Informations.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

reader.Skip(2); // skip read short
			this.Informations = new TaxCollectorInformations();
			this.Informations.Deserialize(reader);

		}


	}
}
