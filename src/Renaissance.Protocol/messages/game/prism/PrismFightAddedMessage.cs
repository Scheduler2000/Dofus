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
using    Renaissance.Protocol.types.game.prism;

namespace Renaissance.Protocol.messages.game.prism
{
	public class PrismFightAddedMessage : IDofusMessage
	{
		public  const int NetworkId = 6452;
		public  int ProtocolId { get { return NetworkId; } }

		public PrismFightersInformation Fight { get; set; }


		public PrismFightAddedMessage() { }


		public PrismFightAddedMessage InitPrismFightAddedMessage(PrismFightersInformation _fight)
		{

			this.Fight = _fight;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.Fight.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Fight = new PrismFightersInformation();
			this.Fight.Deserialize(reader);

		}


	}
}
