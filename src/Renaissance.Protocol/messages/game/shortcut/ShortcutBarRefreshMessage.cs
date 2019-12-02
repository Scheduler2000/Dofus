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
using    Renaissance.Protocol.types.game.shortcut;

namespace Renaissance.Protocol.messages.game.shortcut
{
	public class ShortcutBarRefreshMessage : IDofusMessage
	{
		public  const int NetworkId = 6229;
		public  int ProtocolId { get { return NetworkId; } }

		public byte BarType { get; set; }

		public Shortcut Shortcut { get; set; }


		public ShortcutBarRefreshMessage() { }


		public ShortcutBarRefreshMessage InitShortcutBarRefreshMessage(byte _bartype, Shortcut _shortcut)
		{

			this.BarType = _bartype;
			this.Shortcut = _shortcut;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.BarType);
			writer.Write((short)(Shortcut.ProtocolId));
			writer.Write(this.Shortcut.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.BarType = reader.Read<byte>();
reader.Skip(2); // skip read short
			this.Shortcut = new Shortcut();
			this.Shortcut.Deserialize(reader);

		}


	}
}
