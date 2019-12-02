//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:18.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.fight
{
	public class GameFightTurnListMessage : IDofusMessage
	{
		public  const int NetworkId = 713;
		public  int ProtocolId { get { return NetworkId; } }

		public double[] Ids { get; set; }

		public double[] DeadsIds { get; set; }


		public GameFightTurnListMessage() { }


		public GameFightTurnListMessage InitGameFightTurnListMessage(double[] _ids, double[] _deadsids)
		{

			this.Ids = _ids;
			this.DeadsIds = _deadsids;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Ids.Length));
			foreach(var item in Ids)
				writer.Write(item);
			writer.Write((short)(this.DeadsIds.Length));
			foreach(var item in DeadsIds)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Ids_length = reader.Read<short>();
			this.Ids = new double[Ids_length];
			for(int i = 0; i < Ids_length; i++)
				this.Ids[i] = reader.Read<double>();
			int DeadsIds_length = reader.Read<short>();
			this.DeadsIds = new double[DeadsIds_length];
			for(int i = 0; i < DeadsIds_length; i++)
				this.DeadsIds[i] = reader.Read<double>();

		}


	}
}
