//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:18.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

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

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.MasterId);
			writer.Write(this.SlaveId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.MasterId = reader.Read<double>();
			this.SlaveId = reader.Read<double>();

		}


	}
}
