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

namespace Renaissance.Protocol.types.game.prism
{
	public class PrismGeolocalizedInformation : PrismSubareaEmptyInfo, IDofusType
	{
		public new const int NetworkId = 434;
		public new int ProtocolId { get { return NetworkId; } }

		public short WorldX { get; set; }

		public short WorldY { get; set; }

		public double MapId { get; set; }

		public PrismInformation Prism { get; set; }


		public PrismGeolocalizedInformation() { }


		public PrismGeolocalizedInformation InitPrismGeolocalizedInformation(short _worldx, short _worldy, double _mapid, PrismInformation _prism)
		{

			this.WorldX = _worldx;
			this.WorldY = _worldy;
			this.MapId = _mapid;
			this.Prism = _prism;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.WorldX);
			writer.Write(this.WorldY);
			writer.Write(this.MapId);
			writer.Write((short)(Prism.ProtocolId));
			writer.Write(this.Prism.Serialize());

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.WorldX = reader.Read<short>();
			this.WorldY = reader.Read<short>();
			this.MapId = reader.Read<double>();
reader.Skip(2); // skip read short
			this.Prism = new PrismInformation();
			this.Prism.Deserialize(reader);

		}


	}
}
