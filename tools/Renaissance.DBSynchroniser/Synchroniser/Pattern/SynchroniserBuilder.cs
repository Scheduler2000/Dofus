using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Renaissance.Data.D2I;
using Renaissance.Data.D2O;
using Renaissance.Data.D2P;
using Renaissance.DBSynchroniser.Synchroniser.World;
using Renaissance.Protocol.datacenter;
using Renaissance.Protocol.datacenter.appearance;
using Renaissance.Protocol.datacenter.breeds;
using Renaissance.Protocol.datacenter.challenges;
using Renaissance.Protocol.datacenter.communication;
using Renaissance.Protocol.datacenter.effects;
using Renaissance.Protocol.datacenter.idols;
using Renaissance.Protocol.datacenter.items;
using Renaissance.Protocol.datacenter.jobs;
using Renaissance.Protocol.datacenter.monsters;
using Renaissance.Protocol.datacenter.mounts;
using Renaissance.Protocol.datacenter.npcs;
using Renaissance.Protocol.datacenter.quest;
using Renaissance.Protocol.datacenter.world;
using Renaissance.World.Database.Achievements;
using Renaissance.World.Database.Achievements.Categories;
using Renaissance.World.Database.Achievements.Objectives;
using Renaissance.World.Database.Achievements.Rewards;
using Renaissance.World.Database.Breeds;
using Renaissance.World.Database.Challenges;
using Renaissance.World.Database.Dungeons;
using Renaissance.World.Database.Effects;
using Renaissance.World.Database.Emoticons;
using Renaissance.World.Database.Heads;
using Renaissance.World.Database.Idols;
using Renaissance.World.Database.Items;
using Renaissance.World.Database.Items.Panoplies;
using Renaissance.World.Database.Items.Weapons;
using Renaissance.World.Database.Jobs;
using Renaissance.World.Database.Jobs.Recipes;
using Renaissance.World.Database.Jobs.Skills;
using Renaissance.World.Database.Maps;
using Renaissance.World.Database.Maps.Positions;
using Renaissance.World.Database.Maps.Scrolls;
using Renaissance.World.Database.Maps.SubAreas;
using Renaissance.World.Database.Monsters;
using Renaissance.World.Database.Mounts;
using Renaissance.World.Database.Npcs;
using Renaissance.World.Database.Ornaments;
using Renaissance.World.Database.Titles;

namespace Renaissance.DBSynchroniser.Synchroniser.Pattern
{
    public class SynchroniserBuilder
    {
        private readonly object m_locker = new object();
        private readonly string m_baseClientPath;

        private readonly List<ISynchroniser> m_syncs;
        private readonly IEnumerable<Type> m_datas;
        private readonly D2IManager m_d2i;


        public SynchroniserBuilder(string baseClientPath)
        {
            this.m_baseClientPath = baseClientPath;
            this.m_syncs = new List<ISynchroniser>();
            this.m_datas = typeof(IDataCenter).Assembly.GetTypes()
                                                       .Where(type => typeof(IDataCenter).IsAssignableFrom(type)
                                                           && type != typeof(IDataCenter));
            this.m_d2i = new D2IManager($@"{m_baseClientPath}\data\i18n\i18n_fr.d2i");
            m_d2i.Load();
        }

        public SynchroniserBuilder Register(string d2oName)
        {
            lock (m_locker)
            {
                var data = File.ReadAllBytes($@"{m_baseClientPath}\data\common\{d2oName}.d2o");
                var reader = new D2OReader(data, m_datas);
                var objects = reader.ReadObjects();

                switch (d2oName)
                {
                    case "Breeds":
                        m_syncs.Add(new BreedSynchroniser(m_d2i, objects.Select(x => x.Value as BreedData), new BreedRepository()));
                        break;
                    case "Monsters":
                        m_syncs.Add(new MonsterSynchroniser(m_d2i, objects.Select(x => x.Value as MonsterData), new MonsterRepository()));
                        break;
                    case "Challenge":
                        m_syncs.Add(new ChallengeSynchroniser(m_d2i, objects.Select(x => x.Value as ChallengeData), new ChallengeRepository()));
                        break;
                    case "Idols":
                        m_syncs.Add(new IdolSynchroniser(objects.Select(x => x.Value as IdolData), new IdolRepository()));
                        break;
                    case "Effects":
                        m_syncs.Add(new EffectSynchroniser(m_d2i, objects.Select(x => x.Value as EffectData), new EffectRepository()));
                        break;
                    case "Mounts":
                        m_syncs.Add(new MountSynchroniser(m_d2i, objects.Select(x => x.Value as MountData), new MountRepository()));
                        break;
                    case "Titles":
                        m_syncs.Add(new TitleSynchroniser(m_d2i, objects.Select(x => x.Value as TitleData), new TitleRepository()));
                        break;
                    case "Ornaments":
                        m_syncs.Add(new OrnamentSynchroniser(m_d2i, objects.Select(x => x.Value as OrnamentData), new OrnamentRepository()));
                        break;
                    case "Emoticons":
                        m_syncs.Add(new EmoticonSynchroniser(m_d2i, objects.Select(x => x.Value as EmoticonData), new EmoticonRepository()));
                        break;
                    case "Items":
                        m_syncs.Add(new ItemSynchroniser(m_d2i, objects.Select(x => x.Value as ItemData).Where(x => (x as WeaponData) == null), new ItemRepository()));
                        m_syncs.Add(new ItemWeaponSynchroniser(m_d2i, objects.Select(x => x.Value as WeaponData).Where(x => x != null), new WeaponRepository()));
                        break;
                    case "ItemSets":
                        m_syncs.Add(new ItemSetSynchroniser(m_d2i, objects.Select(x => x.Value as ItemSetData), new ItemSetRepository()));
                        break;
                    case "Npcs":
                        m_syncs.Add(new NpcSynchroniser(m_d2i, objects.Select(x => x.Value as NpcData), new NpcRepository()));
                        break;
                    case "Jobs":
                        m_syncs.Add(new JobSynchroniser(m_d2i, objects.Select(x => x.Value as JobData), new JobRepository()));
                        break;
                    case "Skills":
                        m_syncs.Add(new JobSkillSynchroniser(m_d2i, objects.Select(x => x.Value as SkillData), new JobSkillRepository()));
                        break;
                    case "Recipes":
                        m_syncs.Add(new JobRecipeSynchroniser(m_d2i, objects.Select(x => x.Value as RecipeData), new JobRecipeRepository()));
                        break;
                    case "Achievements":
                        m_syncs.Add(new AchievementSynchroniser(m_d2i, objects.Select(x => x.Value as AchievementData), new AchievementRepository()));
                        break;
                    case "AchievementCategories":
                        m_syncs.Add(new AchievementCategorySynchroniser(m_d2i, objects.Select(x => x.Value as AchievementCategoryData), new AchievementCategoryRepository()));
                        break;
                    case "AchievementObjectives":
                        m_syncs.Add(new AchievementObjectiveSynchroniser(m_d2i, objects.Select(x => x.Value as AchievementObjectiveData), new AchievementObjectiveRepository()));
                        break;
                    case "AchievementRewards":
                        m_syncs.Add(new AchievementRewardSynchroniser(objects.Select(x => x.Value as AchievementRewardData), new AchievementRewardRepository()));
                        break;
                    case "Dungeons":
                        m_syncs.Add(new DungeonSynchroniser(m_d2i, objects.Select(x => x.Value as DungeonData), new DungeonRepository()));
                        break;
                    case "MapScrollActions":
                        m_syncs.Add(new MapScrollActionSynchroniser(objects.Select(x => x.Value as MapScrollActionData), new MapScrollActionRepository()));
                        break;
                    case "SubAreas":
                        m_syncs.Add(new MapSubAreaSynchroniser(objects.Select(x => x.Value as SubAreaData), new MapSubAreaRepository()));
                        break;
                    case "MapPositions":
                        m_syncs.Add(new MapPositionSynchroniser(objects.Select(x => x.Value as MapPositionData), new MapPositionRepository()));
                        break;
                    case "Heads":
                        m_syncs.Add(new HeadSynchroniser(objects.Select(x => x.Value as HeadData), new HeadRepository()));
                        break;
                    default:
                        throw new FileNotFoundException($"{d2oName} doesn't map a synchroniser !");
                }
                return this;
            }
        }

        public SynchroniserBuilder Register(string[] d2pFiles)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Extraction des maps...");

            var manager = new D2PManager(d2pFiles);
            var datas = manager.ExtractAllData();

            Console.WriteLine("Extraction terminée avec succès !");
            Console.ForegroundColor = ConsoleColor.White;


            m_syncs.Add(new MapSynchroniser(datas, new MapRepository()));

            return this;
        }

        public DatabaseSynchroniser Build()
        {
            Console.WriteLine(Environment.NewLine);
            return new DatabaseSynchroniser(m_syncs);
        }
    }
}
