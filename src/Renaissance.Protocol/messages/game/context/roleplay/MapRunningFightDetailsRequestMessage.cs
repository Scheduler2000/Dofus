//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:19.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay
{
	public class MapRunningFightDetailsRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 5750;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> FightId { get; set; }


		public MapRunningFightDetailsRequestMessage() { }


		public MapRunningFightDetailsRequestMessage InitMapRunningFightDetailsRequestMessage(CustomVar<short> _fightid)
		{

			this.FightId = _fightid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.FightId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.FightId = reader.Read<CustomVar<short>>();

		}


	}
}
