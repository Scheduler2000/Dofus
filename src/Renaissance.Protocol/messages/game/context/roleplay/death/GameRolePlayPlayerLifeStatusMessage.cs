//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:23.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.death
{
	public class GameRolePlayPlayerLifeStatusMessage : IDofusMessage
	{
		public  const int NetworkId = 5996;
		public  int ProtocolId { get { return NetworkId; } }

		public byte State { get; set; }

		public double PhenixMapId { get; set; }


		public GameRolePlayPlayerLifeStatusMessage() { }


		public GameRolePlayPlayerLifeStatusMessage InitGameRolePlayPlayerLifeStatusMessage(byte _state, double _phenixmapid)
		{

			this.State = _state;
			this.PhenixMapId = _phenixmapid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.State);
			writer.Write(this.PhenixMapId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.State = reader.Read<byte>();
			this.PhenixMapId = reader.Read<double>();

		}


	}
}
