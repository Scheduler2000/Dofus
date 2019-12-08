//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:43.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.basic
{
	public class BasicLatencyStatsMessage : IDofusMessage
	{
		public  const int NetworkId = 5663;
		public  int ProtocolId { get { return NetworkId; } }

		public short Latency { get; set; }

		public CustomVar<short> SampleCount { get; set; }

		public CustomVar<short> Max { get; set; }


		public BasicLatencyStatsMessage() { }


		public BasicLatencyStatsMessage InitBasicLatencyStatsMessage(short _latency, CustomVar<short> _samplecount, CustomVar<short> _max)
		{

			this.Latency = _latency;
			this.SampleCount = _samplecount;
			this.Max = _max;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Latency);
			size += DofusBinaryFactory.Sizing.SizeOf(SampleCount);
			size += DofusBinaryFactory.Sizing.SizeOf(Max);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Latency);
			writer.WriteData(this.SampleCount);
			writer.WriteData(this.Max);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Latency = reader.Read<short>();
			this.SampleCount = reader.Read<CustomVar<short>>();
			this.Max = reader.Read<CustomVar<short>>();

		}


	}
}
