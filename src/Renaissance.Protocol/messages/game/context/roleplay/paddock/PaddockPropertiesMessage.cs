//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:55.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.paddock;

namespace Renaissance.Protocol.messages.game.context.roleplay.paddock
{
	public class PaddockPropertiesMessage : IDofusMessage
	{
		public  const int NetworkId = 5824;
		public  int ProtocolId { get { return NetworkId; } }

		public PaddockInstancesInformations Properties { get; set; }


		public PaddockPropertiesMessage() { }


		public PaddockPropertiesMessage InitPaddockPropertiesMessage(PaddockInstancesInformations _properties)
		{

			this.Properties = _properties;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.Properties.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Properties = new PaddockInstancesInformations();
			this.Properties.Deserialize(reader);

		}


	}
}
