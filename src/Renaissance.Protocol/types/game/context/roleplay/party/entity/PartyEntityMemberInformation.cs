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
using    Renaissance.Protocol.types.game.look;

namespace Renaissance.Protocol.types.game.context.roleplay.party.entity
{
	public class PartyEntityMemberInformation : PartyEntityBaseInformation, IDofusType
	{
		public new const int NetworkId = 550;
		public new int ProtocolId { get { return NetworkId; } }

		public CustomVar<short> Initiative { get; set; }

		public CustomVar<int> LifePoints { get; set; }

		public CustomVar<int> MaxLifePoints { get; set; }

		public CustomVar<short> Prospecting { get; set; }

		public byte RegenRate { get; set; }


		public PartyEntityMemberInformation() { }


		public PartyEntityMemberInformation InitPartyEntityMemberInformation(byte _indexid, byte _entitymodelid, EntityLook _entitylook, CustomVar<short> _initiative, CustomVar<int> _lifepoints, CustomVar<int> _maxlifepoints, CustomVar<short> _prospecting, byte _regenrate)
		{

			base.IndexId = _indexid;
			base.EntityModelId = _entitymodelid;
			base.EntityLook = _entitylook;
			this.Initiative = _initiative;
			this.LifePoints = _lifepoints;
			this.MaxLifePoints = _maxlifepoints;
			this.Prospecting = _prospecting;
			this.RegenRate = _regenrate;

			return this;
		}

		public new Memory<byte> Serialize()
		{

			int size = default;

			size += DofusBinaryFactory.Sizing.SizeOf(Initiative);
			size += DofusBinaryFactory.Sizing.SizeOf(LifePoints);
			size += DofusBinaryFactory.Sizing.SizeOf(MaxLifePoints);
			size += DofusBinaryFactory.Sizing.SizeOf(Prospecting);
			size += DofusBinaryFactory.Sizing.SizeOf(RegenRate);
			var parent = base.Serialize();
			size += parent.Length;


			using DofusWriter writer = new DofusWriter(size);

			writer.WriteDatas(parent);
			writer.WriteData(this.Initiative);
			writer.WriteData(this.LifePoints);
			writer.WriteData(this.MaxLifePoints);
			writer.WriteData(this.Prospecting);
			writer.WriteData(this.RegenRate);

			return writer.Data;
		}

		public new void Deserialize(DofusReader reader)
		{

			base.Deserialize(reader);
			this.Initiative = reader.Read<CustomVar<short>>();
			this.LifePoints = reader.Read<CustomVar<int>>();
			this.MaxLifePoints = reader.Read<CustomVar<int>>();
			this.Prospecting = reader.Read<CustomVar<short>>();
			this.RegenRate = reader.Read<byte>();

		}


	}
}
