//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:18.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.mount
{
	public class PaddockRemoveItemRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5958;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> CellId { get; set; }


		public PaddockRemoveItemRequestMessage() { }


		public PaddockRemoveItemRequestMessage InitPaddockRemoveItemRequestMessage(CustomVar<short> _cellid)
		{

			this.CellId = _cellid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.CellId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.CellId = reader.Read<CustomVar<short>>();

		}


	}
}