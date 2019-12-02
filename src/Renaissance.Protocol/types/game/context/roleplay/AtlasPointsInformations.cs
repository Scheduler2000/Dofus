//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:30.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.context;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class AtlasPointsInformations : IDofusType
	{
		public  const int NetworkId = 175;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Type { get; set; }

		public MapCoordinatesExtended[] Coords { get; set; }


		public AtlasPointsInformations() { }


		public AtlasPointsInformations InitAtlasPointsInformations(byte _type, MapCoordinatesExtended[] _coords)
		{

			this.Type = _type;
			this.Coords = _coords;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Type);
			writer.Write((short)(this.Coords.Length));
			foreach(var obj in Coords)
			{
				writer.Write(obj.Serialize());
			}

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Type = reader.Read<byte>();
			int Coords_length = reader.Read<short>();
			this.Coords = new MapCoordinatesExtended[Coords_length];
			for(int i = 0; i < Coords_length; i++)
			{
				this.Coords[i] = new MapCoordinatesExtended();
				this.Coords[i].Deserialize(reader);
			}

		}


	}
}
