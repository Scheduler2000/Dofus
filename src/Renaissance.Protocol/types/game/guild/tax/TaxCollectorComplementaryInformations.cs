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

namespace Renaissance.Protocol.types.game.guild.tax
{
	public class TaxCollectorComplementaryInformations : IDofusType
	{
		public  const int NetworkId = 448;
		public  int ProtocolId { get { return NetworkId; } }


		public TaxCollectorComplementaryInformations() { }


		public TaxCollectorComplementaryInformations InitTaxCollectorComplementaryInformations()
		{


			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();


			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{


		}


	}
}
