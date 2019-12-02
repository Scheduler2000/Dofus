//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:17.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.fight
{
	public class GameFightPlacementPositionRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 704;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> CellId { get; set; }


		public GameFightPlacementPositionRequestMessage() { }


		public GameFightPlacementPositionRequestMessage InitGameFightPlacementPositionRequestMessage(CustomVar<short> _cellid)
		{

			this.CellId = _cellid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.CellId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.CellId = reader.Read<CustomVar<short>>();

		}


	}
}