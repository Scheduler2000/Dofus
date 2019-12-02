//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:15.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.web.ankabox
{
	public class MailStatusMessage : IDofusMessage
	{
		public  const int NetworkId = 6275;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Unread { get; set; }

		public CustomVar<short> Total { get; set; }


		public MailStatusMessage() { }


		public MailStatusMessage InitMailStatusMessage(CustomVar<short> _unread, CustomVar<short> _total)
		{

			this.Unread = _unread;
			this.Total = _total;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Unread);
			writer.Write(this.Total);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Unread = reader.Read<CustomVar<short>>();
			this.Total = reader.Read<CustomVar<short>>();

		}


	}
}