//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:41.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.common.basic
{
	public class BasicStatMessage : IDofusMessage
	{
		public  const int NetworkId = 6530;
		public  int ProtocolId { get { return NetworkId; } }

		public double TimeSpent { get; set; }

		public CustomVar<short> StatId { get; set; }


		public BasicStatMessage() { }


		public BasicStatMessage InitBasicStatMessage(double _timespent, CustomVar<short> _statid)
		{

			this.TimeSpent = _timespent;
			this.StatId = _statid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(TimeSpent);
			size += DofusBinaryFactory.Sizing.SizeOf(StatId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.TimeSpent);
			writer.WriteData(this.StatId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.TimeSpent = reader.Read<double>();
			this.StatId = reader.Read<CustomVar<short>>();

		}


	}
}
