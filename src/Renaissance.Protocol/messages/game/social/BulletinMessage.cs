//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:46.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.social
{
	public class BulletinMessage : SocialNoticeMessage, IDofusMessage
	{
		public new const int NetworkId = 6695;
		public new int ProtocolId { get { return NetworkId; } }

		public int LastNotifiedTimestamp { get; set; }


		public BulletinMessage() { }


		public BulletinMessage InitBulletinMessage(int _lastnotifiedtimestamp)
		{

			this.LastNotifiedTimestamp = _lastnotifiedtimestamp;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(LastNotifiedTimestamp);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.LastNotifiedTimestamp);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.LastNotifiedTimestamp = reader.Read<int>();

		}


	}
}
