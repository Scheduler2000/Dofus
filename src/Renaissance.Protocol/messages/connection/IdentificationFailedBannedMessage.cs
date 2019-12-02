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

namespace Renaissance.Protocol.messages.connection
{
	public class IdentificationFailedBannedMessage : IdentificationFailedMessage, IDofusMessage
	{
		public new const int NetworkId = 6174;
		public new int ProtocolId { get { return NetworkId; } }

		public double BanEndDate { get; set; }


		public IdentificationFailedBannedMessage() { }


		public IdentificationFailedBannedMessage InitIdentificationFailedBannedMessage(double _banenddate)
		{

			this.BanEndDate = _banenddate;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.BanEndDate);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.BanEndDate = reader.Read<double>();

		}


	}
}