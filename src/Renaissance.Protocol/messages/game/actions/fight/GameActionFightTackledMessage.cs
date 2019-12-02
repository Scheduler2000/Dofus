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
	public class GameActionFightTackledMessage : AbstractGameActionMessage, IDofusMessage
	{
		public new const int NetworkId = 1004;
		public new int ProtocolId { get { return NetworkId; } }

		public double[] TacklersIds { get; set; }


		public GameActionFightTackledMessage() { }


		public GameActionFightTackledMessage InitGameActionFightTackledMessage(double[] _tacklersids)
		{

			this.TacklersIds = _tacklersids;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write((short)(this.TacklersIds.Length));
			foreach(var item in TacklersIds)
				writer.Write(item);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			int TacklersIds_length = reader.Read<short>();
			this.TacklersIds = new double[TacklersIds_length];
			for(int i = 0; i < TacklersIds_length; i++)
				this.TacklersIds[i] = reader.Read<double>();

		}


	}
}