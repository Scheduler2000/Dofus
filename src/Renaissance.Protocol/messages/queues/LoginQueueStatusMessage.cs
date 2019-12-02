//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:07.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.queues
{
	public class LoginQueueStatusMessage : IDofusMessage
	{
		public  const int NetworkId = 10;
		public  int ProtocolId { get { return NetworkId; } }

		public short Position { get; set; }

		public short Total { get; set; }


		public LoginQueueStatusMessage() { }


		public LoginQueueStatusMessage InitLoginQueueStatusMessage(short _position, short _total)
		{

			this.Position = _position;
			this.Total = _total;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Position);
			writer.Write(this.Total);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Position = reader.Read<short>();
			this.Total = reader.Read<short>();

		}


	}
}