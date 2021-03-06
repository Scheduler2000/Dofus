//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:44.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context;

namespace Renaissance.Protocol.messages.game.context
{
	public class GameEntityDispositionMessage : IDofusMessage
	{
		public  const int NetworkId = 5693;
		public  int ProtocolId { get { return NetworkId; } }

		public IdentifiedEntityDispositionInformations Disposition { get; set; }


		public GameEntityDispositionMessage() { }


		public GameEntityDispositionMessage InitGameEntityDispositionMessage(IdentifiedEntityDispositionInformations _disposition)
		{

			this.Disposition = _disposition;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.Disposition.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Disposition = new IdentifiedEntityDispositionInformations();
			this.Disposition.Deserialize(reader);

		}


	}
}
