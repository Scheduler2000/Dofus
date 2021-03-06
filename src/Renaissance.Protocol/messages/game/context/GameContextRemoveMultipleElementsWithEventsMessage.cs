//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:43.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context
{
	public class GameContextRemoveMultipleElementsWithEventsMessage : GameContextRemoveMultipleElementsMessage, IDofusMessage
	{
		public new const int NetworkId = 6416;
		public new int ProtocolId { get { return NetworkId; } }

		public byte[] ElementEventIds { get; set; }


		public GameContextRemoveMultipleElementsWithEventsMessage() { }


		public GameContextRemoveMultipleElementsWithEventsMessage InitGameContextRemoveMultipleElementsWithEventsMessage(double[] _elementsids, byte[] _elementeventids)
		{

			base.ElementsIds = _elementsids;
			this.ElementEventIds = _elementeventids;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.ElementEventIds.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(ElementEventIds);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData((short)(this.ElementEventIds.Length));
			writer.WriteDatas(ElementEventIds);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			int ElementEventIds_length = reader.Read<short>();
			this.ElementEventIds = new byte[ElementEventIds_length];
			for(int i = 0; i < ElementEventIds_length; i++)
				this.ElementEventIds[i] = reader.Read<byte>();

		}


	}
}
