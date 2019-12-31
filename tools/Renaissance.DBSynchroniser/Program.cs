using System;
using System.IO;

using Figgle;

using Renaissance.DBSynchroniser.Synchroniser.Pattern;

namespace Renaissance.DBSynchroniser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Database Synchroniser 2.53";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(FiggleFonts.Ogre.Render("Synchroniser"));
            Console.ForegroundColor = ConsoleColor.White;

            var baseClientPath = @"C:\Users\Perospero\Desktop\Client2.53";

            var databaseSynchroniser = new SynchroniserBuilder(baseClientPath)
                                  .Register("Mounts")
                                  .Register("Effects")
                                  .Register("Idols")
                                  .Register("Monsters")
                                  .Register("Dungeons")
                                  .Register("Challenge")
                                  .Register("Titles")
                                  .Register("Ornaments")
                                  .Register("Emoticons")
                                  .Register("Items")
                                  .Register("ItemSets")
                                  .Register("Jobs")
                                  .Register("Skills")
                                  .Register("Achievements")
                                  .Register("AchievementCategories")
                                  .Register("AchievementObjectives")
                                  .Register("AchievementRewards")
                                  .Register("MapScrollActions")
                                  .Register("SubAreas")
                                  .Register("MapPositions")
                               //   .Register(Directory.GetFiles($@"{baseClientPath}\content\maps", "*.d2p"))
                                  .Register("Recipes")
                                  .Register("Npcs")
                                  .Register("Heads")
                                  .Register("Breeds")
                                  .Build();

            databaseSynchroniser.Sync();
        }

    }
}
