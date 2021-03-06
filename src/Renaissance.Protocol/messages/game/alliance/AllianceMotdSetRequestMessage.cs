//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:42.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.messages.game.social;

namespace Renaissance.Protocol.messages.game.alliance
{
	public class AllianceMotdSetRequestMessage : SocialNoticeSetRequestMessage, IDofusMessage
	{
		public new const int NetworkId = 6687;
		public new int ProtocolId { get { return NetworkId; } }

		public string Content { get; set; }


		public AllianceMotdSetRequestMessage() { }


		public AllianceMotdSetRequestMessage InitAllianceMotdSetRequestMessage(string _content)
		{

			this.Content = _content;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Content);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.Content);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Content = reader.Read<string>();

		}


	}
}
