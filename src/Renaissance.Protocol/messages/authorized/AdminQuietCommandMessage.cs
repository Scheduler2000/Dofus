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

namespace Renaissance.Protocol.messages.authorized
{
	public class AdminQuietCommandMessage : AdminCommandMessage, IDofusMessage
	{
		public new const int NetworkId = 5662;
		public new int ProtocolId { get { return NetworkId; } }


		public AdminQuietCommandMessage() { }


		public AdminQuietCommandMessage InitAdminQuietCommandMessage(string _content)
		{

			base.Content = _content;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);

		}


	}
}
