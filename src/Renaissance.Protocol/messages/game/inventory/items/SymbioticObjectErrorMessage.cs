//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:22.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.inventory.items
{
	public class SymbioticObjectErrorMessage : ObjectErrorMessage, IDofusMessage
	{
		public new const int NetworkId = 6526;
		public new int ProtocolId { get { return NetworkId; } }

		public byte ErrorCode { get; set; }


		public SymbioticObjectErrorMessage() { }


		public SymbioticObjectErrorMessage InitSymbioticObjectErrorMessage(byte _errorcode)
		{

			this.ErrorCode = _errorcode;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.ErrorCode);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.ErrorCode = reader.Read<byte>();

		}


	}
}
