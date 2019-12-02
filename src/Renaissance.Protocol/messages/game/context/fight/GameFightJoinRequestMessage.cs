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
	public class GameFightJoinRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 701;
		public  int ProtocolId { get { return NetworkId; } }

		public double FighterId { get; set; }

		public CustomVar<short> FightId { get; set; }


		public GameFightJoinRequestMessage() { }


		public GameFightJoinRequestMessage InitGameFightJoinRequestMessage(double _fighterid, CustomVar<short> _fightid)
		{

			this.FighterId = _fighterid;
			this.FightId = _fightid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.FighterId);
			writer.Write(this.FightId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.FighterId = reader.Read<double>();
			this.FightId = reader.Read<CustomVar<short>>();

		}


	}
}