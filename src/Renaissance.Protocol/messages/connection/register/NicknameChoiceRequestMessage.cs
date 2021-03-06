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

namespace Renaissance.Protocol.messages.connection.register
{
	public class NicknameChoiceRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5639;
		public  int ProtocolId { get { return NetworkId; } }

		public string Nickname { get; set; }


		public NicknameChoiceRequestMessage() { }


		public NicknameChoiceRequestMessage InitNicknameChoiceRequestMessage(string _nickname)
		{

			this.Nickname = _nickname;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Nickname);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Nickname);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Nickname = reader.Read<string>();

		}


	}
}
