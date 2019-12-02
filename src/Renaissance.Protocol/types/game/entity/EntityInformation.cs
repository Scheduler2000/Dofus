//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:27.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.entity
{
	public class EntityInformation : IDofusType
	{
		public  const int NetworkId = 546;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Id { get; set; }

		public CustomVar<int> Experience { get; set; }

		public bool Status { get; set; }


		public EntityInformation() { }


		public EntityInformation InitEntityInformation(CustomVar<short> _id, CustomVar<int> _experience, bool _status)
		{

			this.Id = _id;
			this.Experience = _experience;
			this.Status = _status;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Id);
			writer.Write(this.Experience);
			writer.Write(this.Status);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Id = reader.Read<CustomVar<short>>();
			this.Experience = reader.Read<CustomVar<int>>();
			this.Status = reader.Read<bool>();

		}


	}
}