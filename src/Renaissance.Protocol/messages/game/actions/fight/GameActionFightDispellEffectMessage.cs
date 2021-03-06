//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:47.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.actions.fight
{
	public class GameActionFightDispellEffectMessage : GameActionFightDispellMessage, IDofusMessage
	{
		public new const int NetworkId = 6113;
		public new int ProtocolId { get { return NetworkId; } }

		public int BoostUID { get; set; }


		public GameActionFightDispellEffectMessage() { }


		public GameActionFightDispellEffectMessage InitGameActionFightDispellEffectMessage(int _boostuid)
		{

			this.BoostUID = _boostuid;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(BoostUID);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.BoostUID);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.BoostUID = reader.Read<int>();

		}


	}
}
