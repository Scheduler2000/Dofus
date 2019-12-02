//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:10.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.finishmoves;

namespace Renaissance.Protocol.messages.game.finishmoves
{
	public class FinishMoveListMessage : IDofusMessage
	{
		public  const int NetworkId = 6704;
		public  int ProtocolId { get { return NetworkId; } }

		public FinishMoveInformations[] FinishMoves { get; set; }


		public FinishMoveListMessage() { }


		public FinishMoveListMessage InitFinishMoveListMessage(FinishMoveInformations[] _finishmoves)
		{

			this.FinishMoves = _finishmoves;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.FinishMoves.Length));
			foreach(var obj in FinishMoves)
			{
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int FinishMoves_length = reader.Read<short>();
			this.FinishMoves = new FinishMoveInformations[FinishMoves_length];
			for(int i = 0; i < FinishMoves_length; i++)
			{
				this.FinishMoves[i] = new FinishMoveInformations();
				this.FinishMoves[i].Deserialize(reader);
			}

		}


	}
}