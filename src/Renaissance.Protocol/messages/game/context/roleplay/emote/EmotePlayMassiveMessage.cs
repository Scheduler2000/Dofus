//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:23.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.emote
{
	public class EmotePlayMassiveMessage : EmotePlayAbstractMessage, IDofusMessage
	{
		public new const int NetworkId = 5691;
		public new int ProtocolId { get { return NetworkId; } }

		public double[] ActorIds { get; set; }


		public EmotePlayMassiveMessage() { }


		public EmotePlayMassiveMessage InitEmotePlayMassiveMessage(double[] _actorids)
		{

			this.ActorIds = _actorids;

			return this;
		}

		public new byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(base.Serialize());
			writer.Write((short)(this.ActorIds.Length));
			foreach(var item in ActorIds)
				writer.Write(item);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			int ActorIds_length = reader.Read<short>();
			this.ActorIds = new double[ActorIds_length];
			for(int i = 0; i < ActorIds_length; i++)
				this.ActorIds[i] = reader.Read<double>();

		}


	}
}
