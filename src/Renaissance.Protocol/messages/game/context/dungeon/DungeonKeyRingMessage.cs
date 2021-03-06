//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:49.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.dungeon
{
	public class DungeonKeyRingMessage : IDofusMessage
	{
		public  const int NetworkId = 6299;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] Availables { get; set; }

		public CustomVar<short>[] Unavailables { get; set; }


		public DungeonKeyRingMessage() { }


		public DungeonKeyRingMessage InitDungeonKeyRingMessage(CustomVar<short>[] _availables, CustomVar<short>[] _unavailables)
		{

			this.Availables = _availables;
			this.Unavailables = _unavailables;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Availables.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(Availables);
			size += DofusBinaryFactory.Sizing.SizeOf((short)(this.Unavailables.Length));
			size += DofusBinaryFactory.Sizing.SizeOf(Unavailables);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData((short)(this.Availables.Length));
			writer.WriteDatas(Availables);
			writer.WriteData((short)(this.Unavailables.Length));
			writer.WriteDatas(Unavailables);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int Availables_length = reader.Read<short>();
			this.Availables = new CustomVar<short>[Availables_length];
			for(int i = 0; i < Availables_length; i++)
				this.Availables[i] = reader.Read<CustomVar<short>>();
			int Unavailables_length = reader.Read<short>();
			this.Unavailables = new CustomVar<short>[Unavailables_length];
			for(int i = 0; i < Unavailables_length; i++)
				this.Unavailables[i] = reader.Read<CustomVar<short>>();

		}


	}
}
