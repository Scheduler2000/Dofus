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

namespace Renaissance.Protocol.types.game.paddock
{
	public class PaddockInformations : IDofusType
	{
		public  const int NetworkId = 132;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> MaxOutdoorMount { get; set; }

		public CustomVar<short> MaxItems { get; set; }


		public PaddockInformations() { }


		public PaddockInformations InitPaddockInformations(CustomVar<short> _maxoutdoormount, CustomVar<short> _maxitems)
		{

			this.MaxOutdoorMount = _maxoutdoormount;
			this.MaxItems = _maxitems;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.MaxOutdoorMount);
			writer.Write(this.MaxItems);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MaxOutdoorMount = reader.Read<CustomVar<short>>();
			this.MaxItems = reader.Read<CustomVar<short>>();

		}


	}
}