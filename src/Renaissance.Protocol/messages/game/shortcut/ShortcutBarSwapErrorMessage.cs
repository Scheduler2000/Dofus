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

namespace Renaissance.Protocol.messages.game.shortcut
{
	public class ShortcutBarSwapErrorMessage : IDofusMessage
	{
		public  const int NetworkId = 6226;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Error { get; set; }


		public ShortcutBarSwapErrorMessage() { }


		public ShortcutBarSwapErrorMessage InitShortcutBarSwapErrorMessage(byte _error)
		{

			this.Error = _error;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Error);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.Error);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Error = reader.Read<byte>();

		}


	}
}
