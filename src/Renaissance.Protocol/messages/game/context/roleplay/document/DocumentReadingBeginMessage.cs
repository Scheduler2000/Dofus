//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:23.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.document
{
	public class DocumentReadingBeginMessage : IDofusMessage
	{
		public  const int NetworkId = 5675;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> DocumentId { get; set; }


		public DocumentReadingBeginMessage() { }


		public DocumentReadingBeginMessage InitDocumentReadingBeginMessage(CustomVar<short> _documentid)
		{

			this.DocumentId = _documentid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.DocumentId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.DocumentId = reader.Read<CustomVar<short>>();

		}


	}
}