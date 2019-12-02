//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:10.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.dare;

namespace Renaissance.Protocol.messages.game.dare
{
	public class DareVersatileListMessage : IDofusMessage
	{
		public  const int NetworkId = 6657;
		public  int ProtocolId { get { return NetworkId; } }

		public DareVersatileInformations[] Dares { get; set; }


		public DareVersatileListMessage() { }


		public DareVersatileListMessage InitDareVersatileListMessage(DareVersatileInformations[] _dares)
		{

			this.Dares = _dares;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.Dares.Length));
			foreach(var obj in Dares)
			{
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Dares_length = reader.Read<short>();
			this.Dares = new DareVersatileInformations[Dares_length];
			for(int i = 0; i < Dares_length; i++)
			{
				this.Dares[i] = new DareVersatileInformations();
				this.Dares[i].Deserialize(reader);
			}

		}


	}
}
