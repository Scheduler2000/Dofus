//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 08/12/2019 12:51:02.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    Renaissance.Binary;
using    Renaissance.Binary.Definition;

namespace Renaissance.Protocol.types.game.context.roleplay.treasureHunt
{
	public class PortalInformation : IDofusType
	{
		public  const int NetworkId = 466;
		public  int ProtocolId { get { return NetworkId; } }

		public int PortalId { get; set; }

		public short AreaId { get; set; }


		public PortalInformation() { }


		public PortalInformation InitPortalInformation(int _portalid, short _areaid)
		{

			this.PortalId = _portalid;
			this.AreaId = _areaid;

			return this;
		}

		public  Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(PortalId);
			size += DofusBinaryFactory.Sizing.SizeOf(AreaId);


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteData(this.PortalId);
			writer.WriteData(this.AreaId);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.PortalId = reader.Read<int>();
			this.AreaId = reader.Read<short>();

		}


	}
}
