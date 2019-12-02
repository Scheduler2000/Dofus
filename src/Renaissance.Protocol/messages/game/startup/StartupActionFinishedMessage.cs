//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:14.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.startup
{
	public class StartupActionFinishedMessage : IDofusMessage
	{
		public  const int NetworkId = 1304;
		public  int ProtocolId { get { return NetworkId; } }

		public WrappedBool Success { get; set; }

		public int ActionId { get; set; }

		public WrappedBool AutomaticAction { get; set; }


		public StartupActionFinishedMessage() { }


		public StartupActionFinishedMessage InitStartupActionFinishedMessage(WrappedBool _success, int _actionid, WrappedBool _automaticaction)
		{

			this.Success = _success;
			this.ActionId = _actionid;
			this.AutomaticAction = _automaticaction;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			byte box = 0;
			box = writer.SetFlag(box,0,this.Success);
			box = writer.SetFlag(box,1,this.AutomaticAction);
			writer.Write(box);
			writer.Write(this.ActionId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			byte box = reader.Read<byte>();
			this.Success = reader.ReadFlag(box,0);
			this.AutomaticAction = reader.ReadFlag(box,1);
			this.ActionId = reader.Read<int>();

		}


	}
}