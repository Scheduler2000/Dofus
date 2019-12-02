//-------------------------------------------------------------------------------
// <auto-generated>
//	This code was generated by a tool.
//  Generated on 07/11/2019 23:09:29.
//	Changes to this file may cause incorrect behavior !
//  Author : Scheduler.
// </auto-generated>
//-------------------------------------------------------------------------------

using    Renaissance.Binary;
using    Renaissance.Binary.Definition;
using    Renaissance.Protocol.types.game.character.alignment;

namespace Renaissance.Protocol.types.game.character.characteristic
{
	public class CharacterCharacteristicsInformations : IDofusType
	{
		public  const int NetworkId = 8;
		public  int ProtocolId { get { return NetworkId; } }

		public CustomVar<long> Experience { get; set; }

		public CustomVar<long> ExperienceLevelFloor { get; set; }

		public CustomVar<long> ExperienceNextLevelFloor { get; set; }

		public CustomVar<long> ExperienceBonusLimit { get; set; }

		public CustomVar<long> Kamas { get; set; }

		public CustomVar<short> StatsPoints { get; set; }

		public CustomVar<short> AdditionnalPoints { get; set; }

		public CustomVar<short> SpellsPoints { get; set; }

		public ActorExtendedAlignmentInformations AlignmentInfos { get; set; }

		public CustomVar<int> LifePoints { get; set; }

		public CustomVar<int> MaxLifePoints { get; set; }

		public CustomVar<short> EnergyPoints { get; set; }

		public CustomVar<short> MaxEnergyPoints { get; set; }

		public CustomVar<short> ActionPointsCurrent { get; set; }

		public CustomVar<short> MovementPointsCurrent { get; set; }

		public CharacterBaseCharacteristic Initiative { get; set; }

		public CharacterBaseCharacteristic Prospecting { get; set; }

		public CharacterBaseCharacteristic ActionPoints { get; set; }

		public CharacterBaseCharacteristic MovementPoints { get; set; }

		public CharacterBaseCharacteristic Strength { get; set; }

		public CharacterBaseCharacteristic Vitality { get; set; }

		public CharacterBaseCharacteristic Wisdom { get; set; }

		public CharacterBaseCharacteristic Chance { get; set; }

		public CharacterBaseCharacteristic Agility { get; set; }

		public CharacterBaseCharacteristic Intelligence { get; set; }

		public CharacterBaseCharacteristic Range { get; set; }

		public CharacterBaseCharacteristic SummonableCreaturesBoost { get; set; }

		public CharacterBaseCharacteristic Reflect { get; set; }

		public CharacterBaseCharacteristic CriticalHit { get; set; }

		public CustomVar<short> CriticalHitWeapon { get; set; }

		public CharacterBaseCharacteristic CriticalMiss { get; set; }

		public CharacterBaseCharacteristic HealBonus { get; set; }

		public CharacterBaseCharacteristic AllDamagesBonus { get; set; }

		public CharacterBaseCharacteristic WeaponDamagesBonusPercent { get; set; }

		public CharacterBaseCharacteristic DamagesBonusPercent { get; set; }

		public CharacterBaseCharacteristic TrapBonus { get; set; }

		public CharacterBaseCharacteristic TrapBonusPercent { get; set; }

		public CharacterBaseCharacteristic GlyphBonusPercent { get; set; }

		public CharacterBaseCharacteristic RuneBonusPercent { get; set; }

		public CharacterBaseCharacteristic PermanentDamagePercent { get; set; }

		public CharacterBaseCharacteristic TackleBlock { get; set; }

		public CharacterBaseCharacteristic TackleEvade { get; set; }

		public CharacterBaseCharacteristic PAAttack { get; set; }

		public CharacterBaseCharacteristic PMAttack { get; set; }

		public CharacterBaseCharacteristic PushDamageBonus { get; set; }

		public CharacterBaseCharacteristic CriticalDamageBonus { get; set; }

		public CharacterBaseCharacteristic NeutralDamageBonus { get; set; }

		public CharacterBaseCharacteristic EarthDamageBonus { get; set; }

		public CharacterBaseCharacteristic WaterDamageBonus { get; set; }

		public CharacterBaseCharacteristic AirDamageBonus { get; set; }

		public CharacterBaseCharacteristic FireDamageBonus { get; set; }

		public CharacterBaseCharacteristic DodgePALostProbability { get; set; }

		public CharacterBaseCharacteristic DodgePMLostProbability { get; set; }

		public CharacterBaseCharacteristic NeutralElementResistPercent { get; set; }

		public CharacterBaseCharacteristic EarthElementResistPercent { get; set; }

		public CharacterBaseCharacteristic WaterElementResistPercent { get; set; }

		public CharacterBaseCharacteristic AirElementResistPercent { get; set; }

		public CharacterBaseCharacteristic FireElementResistPercent { get; set; }

		public CharacterBaseCharacteristic NeutralElementReduction { get; set; }

		public CharacterBaseCharacteristic EarthElementReduction { get; set; }

		public CharacterBaseCharacteristic WaterElementReduction { get; set; }

		public CharacterBaseCharacteristic AirElementReduction { get; set; }

		public CharacterBaseCharacteristic FireElementReduction { get; set; }

		public CharacterBaseCharacteristic PushDamageReduction { get; set; }

		public CharacterBaseCharacteristic CriticalDamageReduction { get; set; }

		public CharacterBaseCharacteristic PvpNeutralElementResistPercent { get; set; }

		public CharacterBaseCharacteristic PvpEarthElementResistPercent { get; set; }

		public CharacterBaseCharacteristic PvpWaterElementResistPercent { get; set; }

		public CharacterBaseCharacteristic PvpAirElementResistPercent { get; set; }

		public CharacterBaseCharacteristic PvpFireElementResistPercent { get; set; }

		public CharacterBaseCharacteristic PvpNeutralElementReduction { get; set; }

		public CharacterBaseCharacteristic PvpEarthElementReduction { get; set; }

		public CharacterBaseCharacteristic PvpWaterElementReduction { get; set; }

		public CharacterBaseCharacteristic PvpAirElementReduction { get; set; }

		public CharacterBaseCharacteristic PvpFireElementReduction { get; set; }

		public CharacterBaseCharacteristic MeleeDamageDonePercent { get; set; }

		public CharacterBaseCharacteristic MeleeDamageReceivedPercent { get; set; }

		public CharacterBaseCharacteristic RangedDamageDonePercent { get; set; }

		public CharacterBaseCharacteristic RangedDamageReceivedPercent { get; set; }

		public CharacterBaseCharacteristic WeaponDamageDonePercent { get; set; }

		public CharacterBaseCharacteristic WeaponDamageReceivedPercent { get; set; }

		public CharacterBaseCharacteristic SpellDamageDonePercent { get; set; }

		public CharacterBaseCharacteristic SpellDamageReceivedPercent { get; set; }

		public CharacterSpellModification[] SpellModifications { get; set; }

		public int ProbationTime { get; set; }


		public CharacterCharacteristicsInformations() { }


		public CharacterCharacteristicsInformations InitCharacterCharacteristicsInformations(CustomVar<long> _experience, CustomVar<long> _experiencelevelfloor, CustomVar<long> _experiencenextlevelfloor, CustomVar<long> _experiencebonuslimit, CustomVar<long> _kamas, CustomVar<short> _statspoints, CustomVar<short> _additionnalpoints, CustomVar<short> _spellspoints, ActorExtendedAlignmentInformations _alignmentinfos, CustomVar<int> _lifepoints, CustomVar<int> _maxlifepoints, CustomVar<short> _energypoints, CustomVar<short> _maxenergypoints, CustomVar<short> _actionpointscurrent, CustomVar<short> _movementpointscurrent, CharacterBaseCharacteristic _initiative, CharacterBaseCharacteristic _prospecting, CharacterBaseCharacteristic _actionpoints, CharacterBaseCharacteristic _movementpoints, CharacterBaseCharacteristic _strength, CharacterBaseCharacteristic _vitality, CharacterBaseCharacteristic _wisdom, CharacterBaseCharacteristic _chance, CharacterBaseCharacteristic _agility, CharacterBaseCharacteristic _intelligence, CharacterBaseCharacteristic _range, CharacterBaseCharacteristic _summonablecreaturesboost, CharacterBaseCharacteristic _reflect, CharacterBaseCharacteristic _criticalhit, CustomVar<short> _criticalhitweapon, CharacterBaseCharacteristic _criticalmiss, CharacterBaseCharacteristic _healbonus, CharacterBaseCharacteristic _alldamagesbonus, CharacterBaseCharacteristic _weapondamagesbonuspercent, CharacterBaseCharacteristic _damagesbonuspercent, CharacterBaseCharacteristic _trapbonus, CharacterBaseCharacteristic _trapbonuspercent, CharacterBaseCharacteristic _glyphbonuspercent, CharacterBaseCharacteristic _runebonuspercent, CharacterBaseCharacteristic _permanentdamagepercent, CharacterBaseCharacteristic _tackleblock, CharacterBaseCharacteristic _tackleevade, CharacterBaseCharacteristic _paattack, CharacterBaseCharacteristic _pmattack, CharacterBaseCharacteristic _pushdamagebonus, CharacterBaseCharacteristic _criticaldamagebonus, CharacterBaseCharacteristic _neutraldamagebonus, CharacterBaseCharacteristic _earthdamagebonus, CharacterBaseCharacteristic _waterdamagebonus, CharacterBaseCharacteristic _airdamagebonus, CharacterBaseCharacteristic _firedamagebonus, CharacterBaseCharacteristic _dodgepalostprobability, CharacterBaseCharacteristic _dodgepmlostprobability, CharacterBaseCharacteristic _neutralelementresistpercent, CharacterBaseCharacteristic _earthelementresistpercent, CharacterBaseCharacteristic _waterelementresistpercent, CharacterBaseCharacteristic _airelementresistpercent, CharacterBaseCharacteristic _fireelementresistpercent, CharacterBaseCharacteristic _neutralelementreduction, CharacterBaseCharacteristic _earthelementreduction, CharacterBaseCharacteristic _waterelementreduction, CharacterBaseCharacteristic _airelementreduction, CharacterBaseCharacteristic _fireelementreduction, CharacterBaseCharacteristic _pushdamagereduction, CharacterBaseCharacteristic _criticaldamagereduction, CharacterBaseCharacteristic _pvpneutralelementresistpercent, CharacterBaseCharacteristic _pvpearthelementresistpercent, CharacterBaseCharacteristic _pvpwaterelementresistpercent, CharacterBaseCharacteristic _pvpairelementresistpercent, CharacterBaseCharacteristic _pvpfireelementresistpercent, CharacterBaseCharacteristic _pvpneutralelementreduction, CharacterBaseCharacteristic _pvpearthelementreduction, CharacterBaseCharacteristic _pvpwaterelementreduction, CharacterBaseCharacteristic _pvpairelementreduction, CharacterBaseCharacteristic _pvpfireelementreduction, CharacterBaseCharacteristic _meleedamagedonepercent, CharacterBaseCharacteristic _meleedamagereceivedpercent, CharacterBaseCharacteristic _rangeddamagedonepercent, CharacterBaseCharacteristic _rangeddamagereceivedpercent, CharacterBaseCharacteristic _weapondamagedonepercent, CharacterBaseCharacteristic _weapondamagereceivedpercent, CharacterBaseCharacteristic _spelldamagedonepercent, CharacterBaseCharacteristic _spelldamagereceivedpercent, CharacterSpellModification[] _spellmodifications, int _probationtime)
		{

			this.Experience = _experience;
			this.ExperienceLevelFloor = _experiencelevelfloor;
			this.ExperienceNextLevelFloor = _experiencenextlevelfloor;
			this.ExperienceBonusLimit = _experiencebonuslimit;
			this.Kamas = _kamas;
			this.StatsPoints = _statspoints;
			this.AdditionnalPoints = _additionnalpoints;
			this.SpellsPoints = _spellspoints;
			this.AlignmentInfos = _alignmentinfos;
			this.LifePoints = _lifepoints;
			this.MaxLifePoints = _maxlifepoints;
			this.EnergyPoints = _energypoints;
			this.MaxEnergyPoints = _maxenergypoints;
			this.ActionPointsCurrent = _actionpointscurrent;
			this.MovementPointsCurrent = _movementpointscurrent;
			this.Initiative = _initiative;
			this.Prospecting = _prospecting;
			this.ActionPoints = _actionpoints;
			this.MovementPoints = _movementpoints;
			this.Strength = _strength;
			this.Vitality = _vitality;
			this.Wisdom = _wisdom;
			this.Chance = _chance;
			this.Agility = _agility;
			this.Intelligence = _intelligence;
			this.Range = _range;
			this.SummonableCreaturesBoost = _summonablecreaturesboost;
			this.Reflect = _reflect;
			this.CriticalHit = _criticalhit;
			this.CriticalHitWeapon = _criticalhitweapon;
			this.CriticalMiss = _criticalmiss;
			this.HealBonus = _healbonus;
			this.AllDamagesBonus = _alldamagesbonus;
			this.WeaponDamagesBonusPercent = _weapondamagesbonuspercent;
			this.DamagesBonusPercent = _damagesbonuspercent;
			this.TrapBonus = _trapbonus;
			this.TrapBonusPercent = _trapbonuspercent;
			this.GlyphBonusPercent = _glyphbonuspercent;
			this.RuneBonusPercent = _runebonuspercent;
			this.PermanentDamagePercent = _permanentdamagepercent;
			this.TackleBlock = _tackleblock;
			this.TackleEvade = _tackleevade;
			this.PAAttack = _paattack;
			this.PMAttack = _pmattack;
			this.PushDamageBonus = _pushdamagebonus;
			this.CriticalDamageBonus = _criticaldamagebonus;
			this.NeutralDamageBonus = _neutraldamagebonus;
			this.EarthDamageBonus = _earthdamagebonus;
			this.WaterDamageBonus = _waterdamagebonus;
			this.AirDamageBonus = _airdamagebonus;
			this.FireDamageBonus = _firedamagebonus;
			this.DodgePALostProbability = _dodgepalostprobability;
			this.DodgePMLostProbability = _dodgepmlostprobability;
			this.NeutralElementResistPercent = _neutralelementresistpercent;
			this.EarthElementResistPercent = _earthelementresistpercent;
			this.WaterElementResistPercent = _waterelementresistpercent;
			this.AirElementResistPercent = _airelementresistpercent;
			this.FireElementResistPercent = _fireelementresistpercent;
			this.NeutralElementReduction = _neutralelementreduction;
			this.EarthElementReduction = _earthelementreduction;
			this.WaterElementReduction = _waterelementreduction;
			this.AirElementReduction = _airelementreduction;
			this.FireElementReduction = _fireelementreduction;
			this.PushDamageReduction = _pushdamagereduction;
			this.CriticalDamageReduction = _criticaldamagereduction;
			this.PvpNeutralElementResistPercent = _pvpneutralelementresistpercent;
			this.PvpEarthElementResistPercent = _pvpearthelementresistpercent;
			this.PvpWaterElementResistPercent = _pvpwaterelementresistpercent;
			this.PvpAirElementResistPercent = _pvpairelementresistpercent;
			this.PvpFireElementResistPercent = _pvpfireelementresistpercent;
			this.PvpNeutralElementReduction = _pvpneutralelementreduction;
			this.PvpEarthElementReduction = _pvpearthelementreduction;
			this.PvpWaterElementReduction = _pvpwaterelementreduction;
			this.PvpAirElementReduction = _pvpairelementreduction;
			this.PvpFireElementReduction = _pvpfireelementreduction;
			this.MeleeDamageDonePercent = _meleedamagedonepercent;
			this.MeleeDamageReceivedPercent = _meleedamagereceivedpercent;
			this.RangedDamageDonePercent = _rangeddamagedonepercent;
			this.RangedDamageReceivedPercent = _rangeddamagereceivedpercent;
			this.WeaponDamageDonePercent = _weapondamagedonepercent;
			this.WeaponDamageReceivedPercent = _weapondamagereceivedpercent;
			this.SpellDamageDonePercent = _spelldamagedonepercent;
			this.SpellDamageReceivedPercent = _spelldamagereceivedpercent;
			this.SpellModifications = _spellmodifications;
			this.ProbationTime = _probationtime;

			return this;
		}

		public  byte[] Serialize()
		{

			using DofusWriter writer = new DofusWriter();

			writer.Write(this.Experience);
			writer.Write(this.ExperienceLevelFloor);
			writer.Write(this.ExperienceNextLevelFloor);
			writer.Write(this.ExperienceBonusLimit);
			writer.Write(this.Kamas);
			writer.Write(this.StatsPoints);
			writer.Write(this.AdditionnalPoints);
			writer.Write(this.SpellsPoints);
			writer.Write(this.AlignmentInfos.Serialize());
			writer.Write(this.LifePoints);
			writer.Write(this.MaxLifePoints);
			writer.Write(this.EnergyPoints);
			writer.Write(this.MaxEnergyPoints);
			writer.Write(this.ActionPointsCurrent);
			writer.Write(this.MovementPointsCurrent);
			writer.Write(this.Initiative.Serialize());
			writer.Write(this.Prospecting.Serialize());
			writer.Write(this.ActionPoints.Serialize());
			writer.Write(this.MovementPoints.Serialize());
			writer.Write(this.Strength.Serialize());
			writer.Write(this.Vitality.Serialize());
			writer.Write(this.Wisdom.Serialize());
			writer.Write(this.Chance.Serialize());
			writer.Write(this.Agility.Serialize());
			writer.Write(this.Intelligence.Serialize());
			writer.Write(this.Range.Serialize());
			writer.Write(this.SummonableCreaturesBoost.Serialize());
			writer.Write(this.Reflect.Serialize());
			writer.Write(this.CriticalHit.Serialize());
			writer.Write(this.CriticalHitWeapon);
			writer.Write(this.CriticalMiss.Serialize());
			writer.Write(this.HealBonus.Serialize());
			writer.Write(this.AllDamagesBonus.Serialize());
			writer.Write(this.WeaponDamagesBonusPercent.Serialize());
			writer.Write(this.DamagesBonusPercent.Serialize());
			writer.Write(this.TrapBonus.Serialize());
			writer.Write(this.TrapBonusPercent.Serialize());
			writer.Write(this.GlyphBonusPercent.Serialize());
			writer.Write(this.RuneBonusPercent.Serialize());
			writer.Write(this.PermanentDamagePercent.Serialize());
			writer.Write(this.TackleBlock.Serialize());
			writer.Write(this.TackleEvade.Serialize());
			writer.Write(this.PAAttack.Serialize());
			writer.Write(this.PMAttack.Serialize());
			writer.Write(this.PushDamageBonus.Serialize());
			writer.Write(this.CriticalDamageBonus.Serialize());
			writer.Write(this.NeutralDamageBonus.Serialize());
			writer.Write(this.EarthDamageBonus.Serialize());
			writer.Write(this.WaterDamageBonus.Serialize());
			writer.Write(this.AirDamageBonus.Serialize());
			writer.Write(this.FireDamageBonus.Serialize());
			writer.Write(this.DodgePALostProbability.Serialize());
			writer.Write(this.DodgePMLostProbability.Serialize());
			writer.Write(this.NeutralElementResistPercent.Serialize());
			writer.Write(this.EarthElementResistPercent.Serialize());
			writer.Write(this.WaterElementResistPercent.Serialize());
			writer.Write(this.AirElementResistPercent.Serialize());
			writer.Write(this.FireElementResistPercent.Serialize());
			writer.Write(this.NeutralElementReduction.Serialize());
			writer.Write(this.EarthElementReduction.Serialize());
			writer.Write(this.WaterElementReduction.Serialize());
			writer.Write(this.AirElementReduction.Serialize());
			writer.Write(this.FireElementReduction.Serialize());
			writer.Write(this.PushDamageReduction.Serialize());
			writer.Write(this.CriticalDamageReduction.Serialize());
			writer.Write(this.PvpNeutralElementResistPercent.Serialize());
			writer.Write(this.PvpEarthElementResistPercent.Serialize());
			writer.Write(this.PvpWaterElementResistPercent.Serialize());
			writer.Write(this.PvpAirElementResistPercent.Serialize());
			writer.Write(this.PvpFireElementResistPercent.Serialize());
			writer.Write(this.PvpNeutralElementReduction.Serialize());
			writer.Write(this.PvpEarthElementReduction.Serialize());
			writer.Write(this.PvpWaterElementReduction.Serialize());
			writer.Write(this.PvpAirElementReduction.Serialize());
			writer.Write(this.PvpFireElementReduction.Serialize());
			writer.Write(this.MeleeDamageDonePercent.Serialize());
			writer.Write(this.MeleeDamageReceivedPercent.Serialize());
			writer.Write(this.RangedDamageDonePercent.Serialize());
			writer.Write(this.RangedDamageReceivedPercent.Serialize());
			writer.Write(this.WeaponDamageDonePercent.Serialize());
			writer.Write(this.WeaponDamageReceivedPercent.Serialize());
			writer.Write(this.SpellDamageDonePercent.Serialize());
			writer.Write(this.SpellDamageReceivedPercent.Serialize());
			writer.Write((short)(this.SpellModifications.Length));
			foreach(var obj in SpellModifications)
			{
				writer.Write(obj.Serialize());
			}
			writer.Write(this.ProbationTime);

			return writer.Data;
		}

		public  void Deserialize(DofusReader reader)
		{

			this.Experience = reader.Read<CustomVar<long>>();
			this.ExperienceLevelFloor = reader.Read<CustomVar<long>>();
			this.ExperienceNextLevelFloor = reader.Read<CustomVar<long>>();
			this.ExperienceBonusLimit = reader.Read<CustomVar<long>>();
			this.Kamas = reader.Read<CustomVar<long>>();
			this.StatsPoints = reader.Read<CustomVar<short>>();
			this.AdditionnalPoints = reader.Read<CustomVar<short>>();
			this.SpellsPoints = reader.Read<CustomVar<short>>();
			this.AlignmentInfos = new ActorExtendedAlignmentInformations();
			this.AlignmentInfos.Deserialize(reader);
			this.LifePoints = reader.Read<CustomVar<int>>();
			this.MaxLifePoints = reader.Read<CustomVar<int>>();
			this.EnergyPoints = reader.Read<CustomVar<short>>();
			this.MaxEnergyPoints = reader.Read<CustomVar<short>>();
			this.ActionPointsCurrent = reader.Read<CustomVar<short>>();
			this.MovementPointsCurrent = reader.Read<CustomVar<short>>();
			this.Initiative = new CharacterBaseCharacteristic();
			this.Initiative.Deserialize(reader);
			this.Prospecting = new CharacterBaseCharacteristic();
			this.Prospecting.Deserialize(reader);
			this.ActionPoints = new CharacterBaseCharacteristic();
			this.ActionPoints.Deserialize(reader);
			this.MovementPoints = new CharacterBaseCharacteristic();
			this.MovementPoints.Deserialize(reader);
			this.Strength = new CharacterBaseCharacteristic();
			this.Strength.Deserialize(reader);
			this.Vitality = new CharacterBaseCharacteristic();
			this.Vitality.Deserialize(reader);
			this.Wisdom = new CharacterBaseCharacteristic();
			this.Wisdom.Deserialize(reader);
			this.Chance = new CharacterBaseCharacteristic();
			this.Chance.Deserialize(reader);
			this.Agility = new CharacterBaseCharacteristic();
			this.Agility.Deserialize(reader);
			this.Intelligence = new CharacterBaseCharacteristic();
			this.Intelligence.Deserialize(reader);
			this.Range = new CharacterBaseCharacteristic();
			this.Range.Deserialize(reader);
			this.SummonableCreaturesBoost = new CharacterBaseCharacteristic();
			this.SummonableCreaturesBoost.Deserialize(reader);
			this.Reflect = new CharacterBaseCharacteristic();
			this.Reflect.Deserialize(reader);
			this.CriticalHit = new CharacterBaseCharacteristic();
			this.CriticalHit.Deserialize(reader);
			this.CriticalHitWeapon = reader.Read<CustomVar<short>>();
			this.CriticalMiss = new CharacterBaseCharacteristic();
			this.CriticalMiss.Deserialize(reader);
			this.HealBonus = new CharacterBaseCharacteristic();
			this.HealBonus.Deserialize(reader);
			this.AllDamagesBonus = new CharacterBaseCharacteristic();
			this.AllDamagesBonus.Deserialize(reader);
			this.WeaponDamagesBonusPercent = new CharacterBaseCharacteristic();
			this.WeaponDamagesBonusPercent.Deserialize(reader);
			this.DamagesBonusPercent = new CharacterBaseCharacteristic();
			this.DamagesBonusPercent.Deserialize(reader);
			this.TrapBonus = new CharacterBaseCharacteristic();
			this.TrapBonus.Deserialize(reader);
			this.TrapBonusPercent = new CharacterBaseCharacteristic();
			this.TrapBonusPercent.Deserialize(reader);
			this.GlyphBonusPercent = new CharacterBaseCharacteristic();
			this.GlyphBonusPercent.Deserialize(reader);
			this.RuneBonusPercent = new CharacterBaseCharacteristic();
			this.RuneBonusPercent.Deserialize(reader);
			this.PermanentDamagePercent = new CharacterBaseCharacteristic();
			this.PermanentDamagePercent.Deserialize(reader);
			this.TackleBlock = new CharacterBaseCharacteristic();
			this.TackleBlock.Deserialize(reader);
			this.TackleEvade = new CharacterBaseCharacteristic();
			this.TackleEvade.Deserialize(reader);
			this.PAAttack = new CharacterBaseCharacteristic();
			this.PAAttack.Deserialize(reader);
			this.PMAttack = new CharacterBaseCharacteristic();
			this.PMAttack.Deserialize(reader);
			this.PushDamageBonus = new CharacterBaseCharacteristic();
			this.PushDamageBonus.Deserialize(reader);
			this.CriticalDamageBonus = new CharacterBaseCharacteristic();
			this.CriticalDamageBonus.Deserialize(reader);
			this.NeutralDamageBonus = new CharacterBaseCharacteristic();
			this.NeutralDamageBonus.Deserialize(reader);
			this.EarthDamageBonus = new CharacterBaseCharacteristic();
			this.EarthDamageBonus.Deserialize(reader);
			this.WaterDamageBonus = new CharacterBaseCharacteristic();
			this.WaterDamageBonus.Deserialize(reader);
			this.AirDamageBonus = new CharacterBaseCharacteristic();
			this.AirDamageBonus.Deserialize(reader);
			this.FireDamageBonus = new CharacterBaseCharacteristic();
			this.FireDamageBonus.Deserialize(reader);
			this.DodgePALostProbability = new CharacterBaseCharacteristic();
			this.DodgePALostProbability.Deserialize(reader);
			this.DodgePMLostProbability = new CharacterBaseCharacteristic();
			this.DodgePMLostProbability.Deserialize(reader);
			this.NeutralElementResistPercent = new CharacterBaseCharacteristic();
			this.NeutralElementResistPercent.Deserialize(reader);
			this.EarthElementResistPercent = new CharacterBaseCharacteristic();
			this.EarthElementResistPercent.Deserialize(reader);
			this.WaterElementResistPercent = new CharacterBaseCharacteristic();
			this.WaterElementResistPercent.Deserialize(reader);
			this.AirElementResistPercent = new CharacterBaseCharacteristic();
			this.AirElementResistPercent.Deserialize(reader);
			this.FireElementResistPercent = new CharacterBaseCharacteristic();
			this.FireElementResistPercent.Deserialize(reader);
			this.NeutralElementReduction = new CharacterBaseCharacteristic();
			this.NeutralElementReduction.Deserialize(reader);
			this.EarthElementReduction = new CharacterBaseCharacteristic();
			this.EarthElementReduction.Deserialize(reader);
			this.WaterElementReduction = new CharacterBaseCharacteristic();
			this.WaterElementReduction.Deserialize(reader);
			this.AirElementReduction = new CharacterBaseCharacteristic();
			this.AirElementReduction.Deserialize(reader);
			this.FireElementReduction = new CharacterBaseCharacteristic();
			this.FireElementReduction.Deserialize(reader);
			this.PushDamageReduction = new CharacterBaseCharacteristic();
			this.PushDamageReduction.Deserialize(reader);
			this.CriticalDamageReduction = new CharacterBaseCharacteristic();
			this.CriticalDamageReduction.Deserialize(reader);
			this.PvpNeutralElementResistPercent = new CharacterBaseCharacteristic();
			this.PvpNeutralElementResistPercent.Deserialize(reader);
			this.PvpEarthElementResistPercent = new CharacterBaseCharacteristic();
			this.PvpEarthElementResistPercent.Deserialize(reader);
			this.PvpWaterElementResistPercent = new CharacterBaseCharacteristic();
			this.PvpWaterElementResistPercent.Deserialize(reader);
			this.PvpAirElementResistPercent = new CharacterBaseCharacteristic();
			this.PvpAirElementResistPercent.Deserialize(reader);
			this.PvpFireElementResistPercent = new CharacterBaseCharacteristic();
			this.PvpFireElementResistPercent.Deserialize(reader);
			this.PvpNeutralElementReduction = new CharacterBaseCharacteristic();
			this.PvpNeutralElementReduction.Deserialize(reader);
			this.PvpEarthElementReduction = new CharacterBaseCharacteristic();
			this.PvpEarthElementReduction.Deserialize(reader);
			this.PvpWaterElementReduction = new CharacterBaseCharacteristic();
			this.PvpWaterElementReduction.Deserialize(reader);
			this.PvpAirElementReduction = new CharacterBaseCharacteristic();
			this.PvpAirElementReduction.Deserialize(reader);
			this.PvpFireElementReduction = new CharacterBaseCharacteristic();
			this.PvpFireElementReduction.Deserialize(reader);
			this.MeleeDamageDonePercent = new CharacterBaseCharacteristic();
			this.MeleeDamageDonePercent.Deserialize(reader);
			this.MeleeDamageReceivedPercent = new CharacterBaseCharacteristic();
			this.MeleeDamageReceivedPercent.Deserialize(reader);
			this.RangedDamageDonePercent = new CharacterBaseCharacteristic();
			this.RangedDamageDonePercent.Deserialize(reader);
			this.RangedDamageReceivedPercent = new CharacterBaseCharacteristic();
			this.RangedDamageReceivedPercent.Deserialize(reader);
			this.WeaponDamageDonePercent = new CharacterBaseCharacteristic();
			this.WeaponDamageDonePercent.Deserialize(reader);
			this.WeaponDamageReceivedPercent = new CharacterBaseCharacteristic();
			this.WeaponDamageReceivedPercent.Deserialize(reader);
			this.SpellDamageDonePercent = new CharacterBaseCharacteristic();
			this.SpellDamageDonePercent.Deserialize(reader);
			this.SpellDamageReceivedPercent = new CharacterBaseCharacteristic();
			this.SpellDamageReceivedPercent.Deserialize(reader);
			int SpellModifications_length = reader.Read<short>();
			this.SpellModifications = new CharacterSpellModification[SpellModifications_length];
			for(int i = 0; i < SpellModifications_length; i++)
			{
				this.SpellModifications[i] = new CharacterSpellModification();
				this.SpellModifications[i].Deserialize(reader);
			}
			this.ProbationTime = reader.Read<int>();

		}


	}
}
