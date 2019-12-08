//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:46.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.social
{
	public class ContactLookRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5932;
		public  int ProtocolId { get { return NetworkId; } }

		public byte RequestId { get; set; }

		public byte ContactType { get; set; }


		public ContactLookRequestMessage() { }


		public ContactLookRequestMessage InitContactLookRequestMessage(byte _requestid, byte _contacttype)
		{

			this.RequestId = _requestid;
			this.ContactType = _contacttype;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(RequestId);
			size += DofusBinaryFactory.Sizing.SizeOf(ContactType);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.RequestId);
			writer.WriteData(this.ContactType);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.RequestId = reader.Read<byte>();
			this.ContactType = reader.Read<byte>();

		}


	}
}
