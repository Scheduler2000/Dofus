//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:09.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context
{
	public class GameContextKickMessage : IDofusMessage
	{
		public  const int NetworkId = 6081;
		public  int ProtocolId { get { return NetworkId; } }

		public double TargetId { get; set; }


		public GameContextKickMessage() { }


		public GameContextKickMessage InitGameContextKickMessage(double _targetid)
		{

			this.TargetId = _targetid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.TargetId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.TargetId = reader.Read<double>();

		}


	}
}