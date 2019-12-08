//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:47.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.tinsel
{
	public class TitleGainedMessage : IDofusMessage
	{
		public  const int NetworkId = 6364;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> TitleId { get; set; }


		public TitleGainedMessage() { }


		public TitleGainedMessage InitTitleGainedMessage(CustomVar<short> _titleid)
		{

			this.TitleId = _titleid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(TitleId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.TitleId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.TitleId = reader.Read<CustomVar<short>>();

		}


	}
}
