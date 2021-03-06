//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:42.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.approach
{
	public class AccountLoggingKickedMessage : IDofusMessage
	{
		public  const int NetworkId = 6029;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Days { get; set; }

		public byte Hours { get; set; }

		public byte Minutes { get; set; }


		public AccountLoggingKickedMessage() { }


		public AccountLoggingKickedMessage InitAccountLoggingKickedMessage(CustomVar<short> _days, byte _hours, byte _minutes)
		{

			this.Days = _days;
			this.Hours = _hours;
			this.Minutes = _minutes;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Days);
			size += DofusBinaryFactory.Sizing.SizeOf(Hours);
			size += DofusBinaryFactory.Sizing.SizeOf(Minutes);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Days);
			writer.WriteData(this.Hours);
			writer.WriteData(this.Minutes);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Days = reader.Read<CustomVar<short>>();
			this.Hours = reader.Read<byte>();
			this.Minutes = reader.Read<byte>();

		}


	}
}
