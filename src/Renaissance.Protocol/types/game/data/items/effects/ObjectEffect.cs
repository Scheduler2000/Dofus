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

namespace Renaissance.Protocol.types.game.data.items.effects
{
	public class ObjectEffect : IDofusType
	{
		public  const int NetworkId = 76;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> ActionId { get; set; }


		public ObjectEffect() { }


		public ObjectEffect InitObjectEffect(CustomVar<short> _actionid)
		{

			this.ActionId = _actionid;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.ActionId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ActionId = reader.Read<CustomVar<short>>();

		}


	}
}
