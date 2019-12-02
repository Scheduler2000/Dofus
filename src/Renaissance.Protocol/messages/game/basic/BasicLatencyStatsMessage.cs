//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:09.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

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

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Latency);
			writer.Write(this.SampleCount);
			writer.Write(this.Max);

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