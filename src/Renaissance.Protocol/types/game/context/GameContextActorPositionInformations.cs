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

namespace Renaissance.Protocol.types.game.context
{
	public class GameContextActorPositionInformations : IDofusType
	{
		public  const int NetworkId = 566;
		public  int ProtocolId { get { return NetworkId; } }

		public double ContextualId { get; set; }

		public EntityDispositionInformations Disposition { get; set; }


		public GameContextActorPositionInformations() { }


		public GameContextActorPositionInformations InitGameContextActorPositionInformations(double _contextualid, EntityDispositionInformations _disposition)
		{

			this.ContextualId = _contextualid;
			this.Disposition = _disposition;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(ContextualId);
			size += 2;
			var serialized1 = this.Disposition.Serialize();
			size += serialized1.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.ContextualId);
			writer.WriteData((short)(Disposition.ProtocolId));
			writer.WriteDatas(serialized1);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.ContextualId = reader.Read<double>();
			reader.Skip(2); // skip protocolManager.GetInstance(short)
			this.Disposition = new EntityDispositionInformations();
			this.Disposition.Deserialize(reader);

		}


	}
}
