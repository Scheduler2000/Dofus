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

namespace Renaissance.Protocol.messages.authorized
{
	public class ConsoleCommandsListMessage : IDofusMessage
	{
		public  const int NetworkId = 6127;
		public  int ProtocolId { get { return NetworkId; } }

		public string[] Aliases { get; set; }

		public string[] Args { get; set; }

		public string[] Descriptions { get; set; }


		public ConsoleCommandsListMessage() { }


		public ConsoleCommandsListMessage InitConsoleCommandsListMessage(string[] _aliases, string[] _args, string[] _descriptions)
		{

			this.Aliases = _aliases;
			this.Args = _args;
			this.Descriptions = _descriptions;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Aliases.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(Aliases);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Args.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(Args);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Descriptions.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(Descriptions);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Aliases.Length));
			writer.WriteDatas(Aliases);
			writer.WriteData((short)(this.Args.Length));
			writer.WriteDatas(Args);
			writer.WriteData((short)(this.Descriptions.Length));
			writer.WriteDatas(Descriptions);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Aliases_length = reader.Read<short>();
			this.Aliases = new string[Aliases_length];
			for(int i = 0; i < Aliases_length; i++)
				this.Aliases[i] = reader.Read<string>();
			int Args_length = reader.Read<short>();
			this.Args = new string[Args_length];
			for(int i = 0; i < Args_length; i++)
				this.Args[i] = reader.Read<string>();
			int Descriptions_length = reader.Read<short>();
			this.Descriptions = new string[Descriptions_length];
			for(int i = 0; i < Descriptions_length; i++)
				this.Descriptions[i] = reader.Read<string>();

		}


	}
}
