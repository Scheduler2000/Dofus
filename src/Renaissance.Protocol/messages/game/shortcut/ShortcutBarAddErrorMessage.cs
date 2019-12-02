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
	public class ShortcutBarAddErrorMessage : IDofusMessage
	{
		public  const int NetworkId = 6227;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Error { get; set; }


		public ShortcutBarAddErrorMessage() { }


		public ShortcutBarAddErrorMessage InitShortcutBarAddErrorMessage(byte _error)
		{

			this.Error = _error;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Error);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Error = reader.Read<byte>();

		}


	}
}