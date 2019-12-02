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

namespace Renaissance.Protocol.messages.game.context.roleplay.delay
{
	public class GameRolePlayDelayedActionMessage : IDofusMessage
	{
		public  const int NetworkId = 6153;
		public  int ProtocolId { get { return NetworkId; } }

		public double DelayedCharacterId { get; set; }

		public byte DelayTypeId { get; set; }

		public double DelayEndTime { get; set; }


		public GameRolePlayDelayedActionMessage() { }


		public GameRolePlayDelayedActionMessage InitGameRolePlayDelayedActionMessage(double _delayedcharacterid, byte _delaytypeid, double _delayendtime)
		{

			this.DelayedCharacterId = _delayedcharacterid;
			this.DelayTypeId = _delaytypeid;
			this.DelayEndTime = _delayendtime;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.DelayedCharacterId);
			writer.Write(this.DelayTypeId);
			writer.Write(this.DelayEndTime);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.DelayedCharacterId = reader.Read<double>();
			this.DelayTypeId = reader.Read<byte>();
			this.DelayEndTime = reader.Read<double>();

		}


	}
}
