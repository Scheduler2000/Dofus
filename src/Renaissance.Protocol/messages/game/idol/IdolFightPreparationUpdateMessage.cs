//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:12.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.idol;

namespace Renaissance.Protocol.messages.game.idol
{
	public class IdolFightPreparationUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 6586;
		public  int ProtocolId { get { return NetworkId; } }

		public byte IdolSource { get; set; }

		public Idol[] Idols { get; set; }


		public IdolFightPreparationUpdateMessage() { }


		public IdolFightPreparationUpdateMessage InitIdolFightPreparationUpdateMessage(byte _idolsource, Idol[] _idols)
		{

			this.IdolSource = _idolsource;
			this.Idols = _idols;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.IdolSource);
			writer.Write((short)(this.Idols.Length));
			foreach(var obj in Idols)
			{
				writer.Write((short)(obj.ProtocolId));
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.IdolSource = reader.Read<byte>();
			int Idols_length = reader.Read<short>();
			this.Idols = new Idol[Idols_length];
			for(int i = 0; i < Idols_length; i++)
			{
reader.Skip(2); // skip read short for protocolManager.GetInstance(short)
				this.Idols[i] = new Idol();
				this.Idols[i].Deserialize(reader);
			}

		}


	}
}
