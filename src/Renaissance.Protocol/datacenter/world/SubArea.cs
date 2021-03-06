//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 27/12/2019 11:41:22.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    System;
using    System.Collections.Generic;
using    Renaissance.Protocol.datacenter.geometry;
using    Renaissance.Protocol.datacenter.ambientSounds;

namespace Renaissance.Protocol.datacenter.world
{
	[D2OClass("SubArea", "com.ankamagames.dofus.datacenter.world")]
	public class SubAreaData : IDataCenter
	{

		private int m_id;
		private uint m_nameId;
		private int m_areaId;
		private List<AmbientSoundData> m_ambientSounds;
		private List<List<int>> m_playlists;
		private List<double> m_mapIds;
		private RectangleData m_bounds;
		private List<int> m_shape;
		private List<uint> m_customWorldMap;
		private int m_packId;
		private uint m_level;
		private Boolean m_isConquestVillage;
		private Boolean m_basicAccountAllowed;
		private Boolean m_displayOnWorldMap;
		private Boolean m_mountAutoTripAllowed;
		private List<uint> m_monsters;
		private List<double> m_entranceMapIds;
		private List<double> m_exitMapIds;
		private Boolean m_capturable;
		private List<uint> m_achievements;
		private List<List<double>> m_quests;
		private List<List<double>> m_npcs;
		private int m_exploreAchievementId;
		private Boolean m_isDiscovered;
		private List<int> m_harvestables;
		private int m_associatedZaapMapId;

		public int Id
		{
			get => m_id;
			set => m_id = value;
		}

		public uint NameId
		{
			get => m_nameId;
			set => m_nameId = value;
		}

		public int AreaId
		{
			get => m_areaId;
			set => m_areaId = value;
		}

		public List<AmbientSoundData> AmbientSounds
		{
			get => m_ambientSounds;
			set => m_ambientSounds = value;
		}

		public List<List<int>> Playlists
		{
			get => m_playlists;
			set => m_playlists = value;
		}

		public List<double> MapIds
		{
			get => m_mapIds;
			set => m_mapIds = value;
		}

		public RectangleData Bounds
		{
			get => m_bounds;
			set => m_bounds = value;
		}

		public List<int> Shape
		{
			get => m_shape;
			set => m_shape = value;
		}

		public List<uint> CustomWorldMap
		{
			get => m_customWorldMap;
			set => m_customWorldMap = value;
		}

		public int PackId
		{
			get => m_packId;
			set => m_packId = value;
		}

		public uint Level
		{
			get => m_level;
			set => m_level = value;
		}

		public Boolean IsConquestVillage
		{
			get => m_isConquestVillage;
			set => m_isConquestVillage = value;
		}

		public Boolean BasicAccountAllowed
		{
			get => m_basicAccountAllowed;
			set => m_basicAccountAllowed = value;
		}

		public Boolean DisplayOnWorldMap
		{
			get => m_displayOnWorldMap;
			set => m_displayOnWorldMap = value;
		}

		public Boolean MountAutoTripAllowed
		{
			get => m_mountAutoTripAllowed;
			set => m_mountAutoTripAllowed = value;
		}

		public List<uint> Monsters
		{
			get => m_monsters;
			set => m_monsters = value;
		}

		public List<double> EntranceMapIds
		{
			get => m_entranceMapIds;
			set => m_entranceMapIds = value;
		}

		public List<double> ExitMapIds
		{
			get => m_exitMapIds;
			set => m_exitMapIds = value;
		}

		public Boolean Capturable
		{
			get => m_capturable;
			set => m_capturable = value;
		}

		public List<uint> Achievements
		{
			get => m_achievements;
			set => m_achievements = value;
		}

		public List<List<double>> Quests
		{
			get => m_quests;
			set => m_quests = value;
		}

		public List<List<double>> Npcs
		{
			get => m_npcs;
			set => m_npcs = value;
		}

		public int ExploreAchievementId
		{
			get => m_exploreAchievementId;
			set => m_exploreAchievementId = value;
		}

		public Boolean IsDiscovered
		{
			get => m_isDiscovered;
			set => m_isDiscovered = value;
		}

		public List<int> Harvestables
		{
			get => m_harvestables;
			set => m_harvestables = value;
		}

		public int AssociatedZaapMapId
		{
			get => m_associatedZaapMapId;
			set => m_associatedZaapMapId = value;
		}


	}
}
