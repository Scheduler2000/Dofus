//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:48.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.actions.fight
{
	public class GameActionFightTriggerEffectMessage : GameActionFightDispellEffectMessage, IDofusMessage
	{
		public new const int NetworkId = 6147;
		public new int ProtocolId { get { return NetworkId; } }


		public GameActionFightTriggerEffectMessage() { }


		public GameActionFightTriggerEffectMessage InitGameActionFightTriggerEffectMessage(int _boostuid, double _targetid, bool _verbosecast, CustomVar<short> _actionid, double _sourceid)
		{

			base.BoostUID = _boostuid;
			base.TargetId = _targetid;
			base.VerboseCast = _verbosecast;
			base.ActionId = _actionid;
			base.SourceId = _sourceid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);

		}


	}
}
