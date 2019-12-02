//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:14.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.shortcut
{
	public class ShortcutBarRemovedMessage : IDofusMessage
	{
		public  const int NetworkId = 6224;
		public  int ProtocolId { get { return NetworkId; } }

		public byte BarType { get; set; }

		public byte Slot { get; set; }


		public ShortcutBarRemovedMessage() { }


		public ShortcutBarRemovedMessage InitShortcutBarRemovedMessage(byte _bartype, byte _slot)
		{

			this.BarType = _bartype;
			this.Slot = _slot;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.BarType);
			writer.Write(this.Slot);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.BarType = reader.Read<byte>();
			this.Slot = reader.Read<byte>();

		}


	}
}
