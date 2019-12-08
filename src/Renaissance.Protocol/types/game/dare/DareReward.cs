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

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Type);
			size += DofusBinaryFactory.Sizing.SizeOf(MonsterId);
			size += DofusBinaryFactory.Sizing.SizeOf(Kamas);
			size += DofusBinaryFactory.Sizing.SizeOf(DareId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Type);
			writer.WriteData(this.MonsterId);
			writer.WriteData(this.Kamas);
			writer.WriteData(this.DareId);

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
