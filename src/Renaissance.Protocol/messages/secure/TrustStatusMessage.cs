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

namespace Renaissance.Protocol.messages.secure
{
	public class TrustStatusMessage : IDofusMessage
	{
		public  const int NetworkId = 6267;
		public  int ProtocolId { get { return NetworkId; } }

		public WrappedBool Trusted { get; set; }

		public WrappedBool Certified { get; set; }


		public TrustStatusMessage() { }


		public TrustStatusMessage InitTrustStatusMessage(WrappedBool _trusted, WrappedBool _certified)
		{

			this.Trusted = _trusted;
			this.Certified = _certified;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			byte box = 0;
			box = writer.SetFlag(box,0,this.Trusted);
			box = writer.SetFlag(box,1,this.Certified);
			writer.Write(box);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			byte box = reader.Read<byte>();
			this.Trusted = reader.ReadFlag(box,0);
			this.Certified = reader.ReadFlag(box,1);

		}


	}
}