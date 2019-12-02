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

namespace Renaissance.Protocol.types.game.dare
{
	public class DareReward : IDofusType
	{
		public  const int NetworkId = 505;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Type { get; set; }

		public CustomVar<short> MonsterId { get; set; }

		public CustomVar<long> Kamas { get; set; }

		public double DareId { get; set; }


		public DareReward() { }


		public DareReward InitDareReward(byte _type, CustomVar<short> _monsterid, CustomVar<long> _kamas, double _dareid)
		{

			this.Type = _type;
			this.MonsterId = _monsterid;
			this.Kamas = _kamas;
			this.DareId = _dareid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Type);
			writer.Write(this.MonsterId);
			writer.Write(this.Kamas);
			writer.Write(this.DareId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Type = reader.Read<byte>();
			this.MonsterId = reader.Read<CustomVar<short>>();
			this.Kamas = reader.Read<CustomVar<long>>();
			this.DareId = reader.Read<double>();

		}


	}
}
