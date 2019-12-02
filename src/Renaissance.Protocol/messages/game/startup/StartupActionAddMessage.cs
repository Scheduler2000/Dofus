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
using    Renaissance.Protocol.types.game.startup;

namespace Renaissance.Protocol.messages.game.startup
{
	public class StartupActionAddMessage : IDofusMessage
	{
		public  const int NetworkId = 6538;
		public  int ProtocolId { get { return NetworkId; } }

		public StartupActionAddObject NewAction { get; set; }


		public StartupActionAddMessage() { }


		public StartupActionAddMessage InitStartupActionAddMessage(StartupActionAddObject _newaction)
		{

			this.NewAction = _newaction;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.NewAction.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.NewAction = new StartupActionAddObject();
			this.NewAction.Deserialize(reader);

		}


	}
}
