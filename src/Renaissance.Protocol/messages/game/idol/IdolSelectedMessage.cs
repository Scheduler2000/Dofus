//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:45.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.idol
{
	public class IdolSelectedMessage : IDofusMessage
	{
		public  const int NetworkId = 6581;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> IdolId { get; set; }

		public WrappedBool Activate { get; set; }

		public WrappedBool Party { get; set; }


		public IdolSelectedMessage() { }


		public IdolSelectedMessage InitIdolSelectedMessage(CustomVar<short> _idolid, WrappedBool _activate, WrappedBool _party)
		{

			this.IdolId = _idolid;
			this.Activate = _activate;
			this.Party = _party;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(IdolId);
			size++;
			size++;


			using DofusWriter writer = new DofusWriter(size);

			byte box = 0;
			box = writer.SetFlag(box,0,this.Activate);
			box = writer.SetFlag(box,1,this.Party);
			writer.WriteData(box);
			writer.WriteData(this.IdolId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			byte box = reader.Read<byte>();
			this.Activate = reader.ReadFlag(box,0);
			this.Party = reader.ReadFlag(box,1);
			this.IdolId = reader.Read<CustomVar<short>>();

		}


	}
}
