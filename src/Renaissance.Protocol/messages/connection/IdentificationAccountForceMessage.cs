//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:41.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.version;

namespace Renaissance.Protocol.messages.connection
{
	public class IdentificationAccountForceMessage : IdentificationMessage, IDofusMessage
	{
		public new const int NetworkId = 6119;
		public new int ProtocolId { get { return NetworkId; } }

		public string ForcedAccountLogin { get; set; }


		public IdentificationAccountForceMessage() { }


		public IdentificationAccountForceMessage InitIdentificationAccountForceMessage(string _forcedaccountlogin)
		{

			this.ForcedAccountLogin = _forcedaccountlogin;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ForcedAccountLogin);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.ForcedAccountLogin);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.ForcedAccountLogin = reader.Read<string>();

		}


	}
}
