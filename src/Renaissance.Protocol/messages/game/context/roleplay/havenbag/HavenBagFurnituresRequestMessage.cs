//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:24.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.messages.game.context.roleplay.havenbag
{
	public class HavenBagFurnituresRequestMessage : IDofusMessage
	{
		public  const int NetworkId = 6637;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short>[] CellIds { get; set; }

		public int[] FunitureIds { get; set; }

		public byte[] Orientations { get; set; }


		public HavenBagFurnituresRequestMessage() { }


		public HavenBagFurnituresRequestMessage InitHavenBagFurnituresRequestMessage(CustomVar<short>[] _cellids, int[] _funitureids, byte[] _orientations)
		{

			this.CellIds = _cellids;
			this.FunitureIds = _funitureids;
			this.Orientations = _orientations;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write((short)(this.CellIds.Length));
			foreach(var item in CellIds)
				writer.Write(item);
			writer.Write((short)(this.FunitureIds.Length));
			foreach(var item in FunitureIds)
				writer.Write(item);
			writer.Write((short)(this.Orientations.Length));
			foreach(var item in Orientations)
				writer.Write(item);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			int CellIds_length = reader.Read<short>();
			this.CellIds = new CustomVar<short>[CellIds_length];
			for(int i = 0; i < CellIds_length; i++)
				this.CellIds[i] = reader.Read<CustomVar<short>>();
			int FunitureIds_length = reader.Read<short>();
			this.FunitureIds = new int[FunitureIds_length];
			for(int i = 0; i < FunitureIds_length; i++)
				this.FunitureIds[i] = reader.Read<int>();
			int Orientations_length = reader.Read<short>();
			this.Orientations = new byte[Orientations_length];
			for(int i = 0; i < Orientations_length; i++)
				this.Orientations[i] = reader.Read<byte>();

		}


	}
}
