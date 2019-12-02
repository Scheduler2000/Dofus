//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:26.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.breach.meeting
{
	public class BreachKickRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6804;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> Target { get; set; }


		public BreachKickRequestMessage() { }


		public BreachKickRequestMessage InitBreachKickRequestMessage(CustomVar<long> _target)
		{

			this.Target = _target;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Target);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Target = reader.Read<CustomVar<long>>();

		}


	}
}