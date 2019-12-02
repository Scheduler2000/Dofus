//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:13.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.messages.game.look
{
	public class AccessoryPreviewMessage : IDofusMessage
	{
		public  const int NetworkId = 6517;
		public  int ProtocolId { get { return NetworkId; } }

		public EntityLook Look { get; set; }


		public AccessoryPreviewMessage() { }


		public AccessoryPreviewMessage InitAccessoryPreviewMessage(EntityLook _look)
		{

			this.Look = _look;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Look.Serialize());

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Look = new EntityLook();
			this.Look.Deserialize(reader);

		}


	}
}