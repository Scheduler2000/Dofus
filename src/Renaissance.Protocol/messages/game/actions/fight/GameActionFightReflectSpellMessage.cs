//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:15.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.messages.game.actions;

namespace Renaissance.Protocol.messages.game.actions.fight
{
	public class GameActionFightReflectSpellMessage : AbstractGameActionMessage, IDofusMessage
	{
		public new const int NetworkId = 5531;
		public new int ProtocolId { get { return NetworkId; } }

		public double TargetId { get; set; }


		public GameActionFightReflectSpellMessage() { }


		public GameActionFightReflectSpellMessage InitGameActionFightReflectSpellMessage(double _targetid)
		{

			this.TargetId = _targetid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.TargetId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.TargetId = reader.Read<double>();

		}


	}
}
