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
using    Renaissance.Protocol.types.game.character;

namespace Renaissance.Protocol.messages.game.context.roleplay.breach.meeting
{
	public class BreachKickResponseMessage : IDofusMessage
	{
		public  const int NetworkId = 6789;
		public  int ProtocolId { get { return NetworkId; } }

		public CharacterMinimalInformations Target { get; set; }

		public bool Kicked { get; set; }


		public BreachKickResponseMessage() { }


		public BreachKickResponseMessage InitBreachKickResponseMessage(CharacterMinimalInformations _target, bool _kicked)
		{

			this.Target = _target;
			this.Kicked = _kicked;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Target.Serialize());
			writer.Write(this.Kicked);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Target = new CharacterMinimalInformations();
			this.Target.Deserialize(reader);
			this.Kicked = reader.Read<bool>();

		}


	}
}
