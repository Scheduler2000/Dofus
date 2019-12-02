//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:11.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.friend
{
	public class IgnoredAddFailureMessage : IDofusMessage
	{
		public  const int NetworkId = 5679;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Reason { get; set; }


		public IgnoredAddFailureMessage() { }


		public IgnoredAddFailureMessage InitIgnoredAddFailureMessage(byte _reason)
		{

			this.Reason = _reason;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Reason);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Reason = reader.Read<byte>();

		}


	}
}
