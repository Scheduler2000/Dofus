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
	public class BasicDateMessage : IDofusMessage
	{
		public  const int NetworkId = 177;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Day { get; set; }

		public byte Month { get; set; }

		public short Year { get; set; }


		public BasicDateMessage() { }


		public BasicDateMessage InitBasicDateMessage(byte _day, byte _month, short _year)
		{

			this.Day = _day;
			this.Month = _month;
			this.Year = _year;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Day);
			writer.Write(this.Month);
			writer.Write(this.Year);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Day = reader.Read<byte>();
			this.Month = reader.Read<byte>();
			this.Year = reader.Read<short>();

		}


	}
}
