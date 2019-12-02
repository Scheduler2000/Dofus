//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:13.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.prism;

namespace Renaissance.Protocol.messages.game.prism
{
	public class PrismsListMessage : IDofusMessage
	{
		public  const int NetworkId = 6440;
		public  int ProtocolId { get { return NetworkId; } }

		public PrismSubareaEmptyInfo[] Prisms { get; set; }


		public PrismsListMessage() { }


		public PrismsListMessage InitPrismsListMessage(PrismSubareaEmptyInfo[] _prisms)
		{

			this.Prisms = _prisms;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Prisms.Length));
			foreach(var obj in Prisms)
			{
				writer.Write((short)(obj.ProtocolId));
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Prisms_length = reader.Read<short>();
			this.Prisms = new PrismSubareaEmptyInfo[Prisms_length];
			for(int i = 0; i < Prisms_length; i++)
			{
reader.Skip(2); // skip read short for protocolManager.GetInstance(short)
				this.Prisms[i] = new PrismSubareaEmptyInfo();
				this.Prisms[i].Deserialize(reader);
			}

		}


	}
}
