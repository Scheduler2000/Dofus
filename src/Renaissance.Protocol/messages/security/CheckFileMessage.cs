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

namespace Renaissance.Protocol.messages.security
{
	public class CheckFileMessage : IDofusMessage
	{
		public  const int NetworkId = 6156;
		public  int ProtocolId { get { return NetworkId; } }

		public string FilenameHash { get; set; }

		public byte Type { get; set; }

		public string Value { get; set; }


		public CheckFileMessage() { }


		public CheckFileMessage InitCheckFileMessage(string _filenamehash, byte _type, string _value)
		{

			this.FilenameHash = _filenamehash;
			this.Type = _type;
			this.Value = _value;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(FilenameHash);
			size += DofusBinaryFactory.Sizing.SizeOf(Type);
			size += DofusBinaryFactory.Sizing.SizeOf(Value);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.FilenameHash);
			writer.WriteData(this.Type);
			writer.WriteData(this.Value);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.FilenameHash = reader.Read<string>();
			this.Type = reader.Read<byte>();
			this.Value = reader.Read<string>();

		}


	}
}
