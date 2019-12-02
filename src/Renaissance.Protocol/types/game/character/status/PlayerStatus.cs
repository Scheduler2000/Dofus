//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:29.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.character.status
{
	public class PlayerStatus : IDofusType
	{
		public  const int NetworkId = 415;
		public  int ProtocolId { get { return NetworkId; } }

		public byte StatusId { get; set; }


		public PlayerStatus() { }


		public PlayerStatus InitPlayerStatus(byte _statusid)
		{

			this.StatusId = _statusid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.StatusId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.StatusId = reader.Read<byte>();

		}


	}
}
