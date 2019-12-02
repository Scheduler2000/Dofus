//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:18.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.fight
{
	public class GameFightTurnStartMessage : IDofusMessage
	{
		public  const int NetworkId = 714;
		public  int ProtocolId { get { return NetworkId; } }

		public double Id { get; set; }

		public CustomVar<int> WaitTime { get; set; }


		public GameFightTurnStartMessage() { }


		public GameFightTurnStartMessage InitGameFightTurnStartMessage(double _id, CustomVar<int> _waittime)
		{

			this.Id = _id;
			this.WaitTime = _waittime;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Id);
			writer.Write(this.WaitTime);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Id = reader.Read<double>();
			this.WaitTime = reader.Read<CustomVar<int>>();

		}


	}
}
