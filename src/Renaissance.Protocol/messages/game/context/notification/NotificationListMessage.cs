//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:50.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.notification
{
	public class NotificationListMessage : IDofusMessage
	{
		public  const int NetworkId = 6087;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<int>[] Flags { get; set; }


		public NotificationListMessage() { }


		public NotificationListMessage InitNotificationListMessage(CustomVar<int>[] _flags)
		{

			this.Flags = _flags;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Flags.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(Flags);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Flags.Length));
			writer.WriteDatas(Flags);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Flags_length = reader.Read<short>();
			this.Flags = new CustomVar<int>[Flags_length];
			for(int i = 0; i < Flags_length; i++)
				this.Flags[i] = reader.Read<CustomVar<int>>();

		}


	}
}
