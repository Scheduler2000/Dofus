//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:47.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.ui
{
	public class ClientUIOpenedByObjectMessage : ClientUIOpenedMessage, IDofusMessage
	{
		public new const int NetworkId = 6463;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<int> Uid { get; set; }


		public ClientUIOpenedByObjectMessage() { }


		public ClientUIOpenedByObjectMessage InitClientUIOpenedByObjectMessage(CustomVar<int> _uid)
		{

			this.Uid = _uid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Uid);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.Uid);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Uid = reader.Read<CustomVar<int>>();

		}


	}
}
