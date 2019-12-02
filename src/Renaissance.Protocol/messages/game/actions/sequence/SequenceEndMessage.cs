//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:16.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.actions.sequence
{
	public class SequenceEndMessage : IDofusMessage
	{
		public  const int NetworkId = 956;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> ActionId { get; set; }

		public double AuthorId { get; set; }

		public byte SequenceType { get; set; }


		public SequenceEndMessage() { }


		public SequenceEndMessage InitSequenceEndMessage(CustomVar<short> _actionid, double _authorid, byte _sequencetype)
		{

			this.ActionId = _actionid;
			this.AuthorId = _authorid;
			this.SequenceType = _sequencetype;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.ActionId);
			writer.Write(this.AuthorId);
			writer.Write(this.SequenceType);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ActionId = reader.Read<CustomVar<short>>();
			this.AuthorId = reader.Read<double>();
			this.SequenceType = reader.Read<byte>();

		}


	}
}