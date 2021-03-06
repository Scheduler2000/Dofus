//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:49.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.fight
{
	public class SlaveNoLongerControledMessage : IDofusMessage
	{
		public  const int NetworkId = 6807;
		public  int ProtocolId { get { return NetworkId; } }

		public double MasterId { get; set; }

		public double SlaveId { get; set; }


		public SlaveNoLongerControledMessage() { }


		public SlaveNoLongerControledMessage InitSlaveNoLongerControledMessage(double _masterid, double _slaveid)
		{

			this.MasterId = _masterid;
			this.SlaveId = _slaveid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(MasterId);
			size += DofusBinaryFactory.Sizing.SizeOf(SlaveId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.MasterId);
			writer.WriteData(this.SlaveId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MasterId = reader.Read<double>();
			this.SlaveId = reader.Read<double>();

		}


	}
}
