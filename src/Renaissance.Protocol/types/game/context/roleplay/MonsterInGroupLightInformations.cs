//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:31.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay
{
	public class MonsterInGroupLightInformations : IDofusType
	{
		public  const int NetworkId = 395;
		public  int ProtocolId { get { return NetworkId; } }

		public int GenericId { get; set; }

		public byte Grade { get; set; }

		public short Level { get; set; }


		public MonsterInGroupLightInformations() { }


		public MonsterInGroupLightInformations InitMonsterInGroupLightInformations(int _genericid, byte _grade, short _level)
		{

			this.GenericId = _genericid;
			this.Grade = _grade;
			this.Level = _level;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.GenericId);
			writer.Write(this.Grade);
			writer.Write(this.Level);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.GenericId = reader.Read<int>();
			this.Grade = reader.Read<byte>();
			this.Level = reader.Read<short>();

		}


	}
}