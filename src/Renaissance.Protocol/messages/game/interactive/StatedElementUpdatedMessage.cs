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
using    Renaissance.Protocol.types.game.interactive;

namespace Renaissance.Protocol.messages.game.interactive
{
	public class StatedElementUpdatedMessage : IDofusMessage
	{
		public  const int NetworkId = 5709;
		public  int ProtocolId { get { return NetworkId; } }

		public StatedElement StatedElement { get; set; }


		public StatedElementUpdatedMessage() { }


		public StatedElementUpdatedMessage InitStatedElementUpdatedMessage(StatedElement _statedelement)
		{

			this.StatedElement = _statedelement;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.StatedElement.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.StatedElement = new StatedElement();
			this.StatedElement.Deserialize(reader);

		}


	}
}
