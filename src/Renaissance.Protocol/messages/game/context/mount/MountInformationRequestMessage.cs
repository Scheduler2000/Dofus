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

namespace Renaissance.Protocol.messages.game.context.mount
{
	public class MountInformationRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5972;
		public  int ProtocolId { get { return NetworkId; } }

		public double Id { get; set; }

		public double Time { get; set; }


		public MountInformationRequestMessage() { }


		public MountInformationRequestMessage InitMountInformationRequestMessage(double _id, double _time)
		{

			this.Id = _id;
			this.Time = _time;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Id);
			size += DofusBinaryFactory.Sizing.SizeOf(Time);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Id);
			writer.WriteData(this.Time);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Id = reader.Read<double>();
			this.Time = reader.Read<double>();

		}


	}
}
