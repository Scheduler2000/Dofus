//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:50:58.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.context
{
	public class GameContextActorInformations : GameContextActorPositionInformations, IDofusType
	{
		public new const int NetworkId = 150;
		public new int ProtocolId { get { return NetworkId; } }

		public EntityLook Look { get; set; }


		public GameContextActorInformations() { }


		public GameContextActorInformations InitGameContextActorInformations(EntityLook _look)
		{

			this.Look = _look;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			var serialized1 = this.Look.Serialize();
			size += serialized1.Length;
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Look = new EntityLook();
			this.Look.Deserialize(reader);

		}


	}
}
