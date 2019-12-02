//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:07.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.security
{
	public class CheckFileRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6154;
		public  int ProtocolId { get { return NetworkId; } }

		public string Filename { get; set; }

		public byte Type { get; set; }


		public CheckFileRequestMessage() { }


		public CheckFileRequestMessage InitCheckFileRequestMessage(string _filename, byte _type)
		{

			this.Filename = _filename;
			this.Type = _type;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Filename);
			writer.Write(this.Type);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Filename = reader.Read<string>();
			this.Type = reader.Read<byte>();

		}


	}
}