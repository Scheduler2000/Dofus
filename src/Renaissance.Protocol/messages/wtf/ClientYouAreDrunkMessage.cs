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
using    Renaissance.Protocol.messages.debug;

namespace Renaissance.Protocol.messages.wtf
{
	public class ClientYouAreDrunkMessage : DebugInClientMessage, IDofusMessage
	{
		public new const int NetworkId = 6594;
		public new int ProtocolId { get { return NetworkId; } }


		public ClientYouAreDrunkMessage() { }


		public ClientYouAreDrunkMessage InitClientYouAreDrunkMessage(byte _level, string _message)
		{

			base.Level = _level;
			base.Message = _message;

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
