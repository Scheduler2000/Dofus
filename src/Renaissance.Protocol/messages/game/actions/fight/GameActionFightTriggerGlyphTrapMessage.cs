//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:16.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.messages.game.actions;

namespace Renaissance.Protocol.messages.game.actions.fight
{
	public class GameActionFightTriggerGlyphTrapMessage : AbstractGameActionMessage, IDofusMessage
	{
		public new const int NetworkId = 5741;
		public new int ProtocolId { get { return NetworkId; } }

		public short MarkId { get; set; }

		public CustomVar<short> MarkImpactCell { get; set; }

		public double TriggeringCharacterId { get; set; }

		public CustomVar<short> TriggeredSpellId { get; set; }


		public GameActionFightTriggerGlyphTrapMessage() { }


		public GameActionFightTriggerGlyphTrapMessage InitGameActionFightTriggerGlyphTrapMessage(short _markid, CustomVar<short> _markimpactcell, double _triggeringcharacterid, CustomVar<short> _triggeredspellid)
		{

			this.MarkId = _markid;
			this.MarkImpactCell = _markimpactcell;
			this.TriggeringCharacterId = _triggeringcharacterid;
			this.TriggeredSpellId = _triggeredspellid;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write(this.MarkId);
			writer.Write(this.MarkImpactCell);
			writer.Write(this.TriggeringCharacterId);
			writer.Write(this.TriggeredSpellId);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.MarkId = reader.Read<short>();
			this.MarkImpactCell = reader.Read<CustomVar<short>>();
			this.TriggeringCharacterId = reader.Read<double>();
			this.TriggeredSpellId = reader.Read<CustomVar<short>>();

		}


	}
}
