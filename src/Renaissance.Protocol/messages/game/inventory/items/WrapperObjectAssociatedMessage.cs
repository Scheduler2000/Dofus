//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:53.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class WrapperObjectAssociatedMessage : SymbioticObjectAssociatedMessage, IDofusMessage
	{
		public new const int NetworkId = 6523;
		public new int ProtocolId { get { return NetworkId; } }


		public WrapperObjectAssociatedMessage() { }


		public WrapperObjectAssociatedMessage InitWrapperObjectAssociatedMessage(CustomVar<int> _hostuid)
		{

			base.HostUID = _hostuid;

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
