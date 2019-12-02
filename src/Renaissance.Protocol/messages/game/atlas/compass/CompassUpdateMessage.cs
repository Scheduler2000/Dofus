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
using    Renaissance.Protocol.types.game.context;

namespace Renaissance.Protocol.messages.game.atlas.compass
{
	public class CompassUpdateMessage : IDofusMessage
	{
		public  const int NetworkId = 5591;
		public  int ProtocolId { get { return NetworkId; } }

		public byte Type { get; set; }

		public MapCoordinates Coords { get; set; }


		public CompassUpdateMessage() { }


		public CompassUpdateMessage InitCompassUpdateMessage(byte _type, MapCoordinates _coords)
		{

			this.Type = _type;
			this.Coords = _coords;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Type);
			writer.Write((short)(Coords.ProtocolId));
			writer.Write(this.Coords.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Type = reader.Read<byte>();
reader.Skip(2); // skip read short
			this.Coords = new MapCoordinates();
			this.Coords.Deserialize(reader);

		}


	}
}