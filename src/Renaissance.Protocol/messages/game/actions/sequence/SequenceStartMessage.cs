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
	public class SequenceStartMessage : IDofusMessage
	{
		public  const int NetworkId = 955;
		public  int ProtocolId { get { return NetworkId; } }

		public byte SequenceType { get; set; }

		public double AuthorId { get; set; }


		public SequenceStartMessage() { }


		public SequenceStartMessage InitSequenceStartMessage(byte _sequencetype, double _authorid)
		{

			this.SequenceType = _sequencetype;
			this.AuthorId = _authorid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.SequenceType);
			writer.Write(this.AuthorId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.SequenceType = reader.Read<byte>();
			this.AuthorId = reader.Read<double>();

		}


	}
}