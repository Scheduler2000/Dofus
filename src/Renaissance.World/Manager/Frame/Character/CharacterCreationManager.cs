using System.Linq;
using System.Text.RegularExpressions;

using Microsoft.Extensions.DependencyInjection;

using Renaissance.Abstract.Manager.Interface;
using Renaissance.Binary.Definition;
using Renaissance.Protocol.enums;
using Renaissance.Protocol.enums.custom;
using Renaissance.Protocol.messages.game.basic;
using Renaissance.Protocol.messages.game.character.choice;
using Renaissance.Protocol.messages.game.character.creation;
using Renaissance.Protocol.messages.game.chat.channel;
using Renaissance.Protocol.messages.game.context.notification;
using Renaissance.Protocol.messages.game.initialization;
using Renaissance.World.Database.Breeds;
using Renaissance.World.Database.Characters;
using Renaissance.World.Database.Heads;
using Renaissance.World.Game.Actors.Characters;
using Renaissance.World.Game.Actors.Look;
using Renaissance.World.IoC;
using Renaissance.World.Manager.Game.EntityLook;
using Renaissance.World.Networking;

using Stump.DofusProtocol.Enums;

namespace Renaissance.World.Manager.Frame.Character
{
    public class CharacterCreationManager : IManager
    {
        private readonly Regex m_nameCheckerRegex =
                      new Regex("^[A-Z][a-z]{2,9}(?:-[A-Za-z][a-z]{2,9}|[a-z]{1,10})$", RegexOptions.Compiled);

        private readonly byte[] m_enabledChannels = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12, 13 };

        public void SendCharacterCreationResultMessage(WorldClient client, CharacterCreationRequestMessage message)
        {
            var characterRepository = ServiceLocator.Provider.GetService<CharacterRepository>();

            if (client.Account.CharactersCount == 5)
            {
                client.Connection.Send(new CharacterCreationResultMessage()
                                 .InitCharacterCreationResultMessage((byte)CharacterCreationResultEnum.ERR_TOO_MANY_CHARACTERS));
                return;
            }

            if (characterRepository.GetEntity(x => x.Name == message.Name) != null)
            {
                client.Connection.Send(new CharacterCreationResultMessage()
                                 .InitCharacterCreationResultMessage((byte)CharacterCreationResultEnum.ERR_NAME_ALREADY_EXISTS));
                return;
            }

            if (message.Name.Split(null).Count() > 1 || !m_nameCheckerRegex.IsMatch(message.Name))
            {
                client.Connection.Send(new CharacterCreationResultMessage()
                                 .InitCharacterCreationResultMessage((byte)CharacterCreationResultEnum.ERR_INVALID_NAME));
                return;
            }

            var breed = ServiceLocator.Provider.GetService<BreedRepository>()
                                               .GetEntity(x => x.Id == message.Breed);
            var head = ServiceLocator.Provider.GetService<HeadRepository>()
                                              .GetEntity(x => x.Id == message.CosmeticId);

            var lookManager = ServiceLocator.Provider.GetService<EntityLookManager>();
            var sexEnum = message.Sex ? SexTypeEnum.SEX_FEMALE : SexTypeEnum.SEX_MALE;

            ContextActorLook look = sexEnum == SexTypeEnum.SEX_MALE ? lookManager.Parse(breed.MaleLook)
                                                             : lookManager.Parse(breed.FemaleLook);

            int[] breedColors = sexEnum == SexTypeEnum.SEX_MALE ? breed.MaleColors : breed.FemaleColors;

            var colors = lookManager.VerifiyColors(message.Colors, message.Sex, breed);
            look.SetColors(lookManager.GetConvertedColors(colors).ToList());

            look.AddSkin(head.SkinId);

            var record = new CharacterRecord(client.Account.Id, breed.Id, head.Id, message.Name,
                                                   1, message.Sex, breed.SpawnMap, 285, DirectionsEnum.DIRECTION_EAST,
                                                   100, 0, 0, 55, 0, 0, 0, 0, 0, look, look);

            ServiceLocator.Provider.GetService<CharacterRepository>()
                                   .Create(record);
            client.Connection.Send(new CharacterCreationResultMessage()
                             .InitCharacterCreationResultMessage((byte)CharacterCreationResultEnum.OK));

            client.Character = new World.Game.Actors.Characters.Character(new CharacterDataAccess(record));
            ProcessSelection(client);
            /*
                        client.Connection.Send(new CharacterSelectedSuccessMessage()            client.Connection.Send(new InventoryContentMessage(client.Selected.ObjectItems, client.Selected.Kamas));
                        client.Connection.Send(new ShortcutBarContentMessage((byte)ShortcutBarEnum.GENERAL_SHORTCUT_BAR, new Shortcut[0]));
                        client.Connection.Send(new ShortcutBarContentMessage((byte)ShortcutBarEnum.SPELL_SHORTCUT_BAR, client.Selected.ShortcutSpells));
                        client.Connection.Send(new HavenBagPackListMessage(new byte[] { 1 }));
                        client.Connection.Send(new EmoteListMessage(new byte[] { 1, 19, 14, 34, 80, 58, 66, 15, 9, 2, 10, 49, 73, 65, 77, 139, 140, 105, 68, 97, 155, 98, 176, 177, 178, 179, 180, 106, 127, 96, 6, 93, 4, 71, 5, 102, 76, 79, 3, 88, 78, 87, 24, 26, 25, 52, 16, 90, 32, 35, 38, 56, 103, 104, 50, 43, 44, 72, 51, 48, 46, 101, 41, 42, 75, 36, 37, 39, 67, 133, 74, 29, 107, 8, 33, 7, 28, 82, 27, 81, 92, 128, 30, 69, 112, 84, 85, 99, 113, 114, 141, 158, 159, 181, 182, 183, 184, 185, 186, 21, 156, 57, 117, 119, 120, 121, 122, 129, 132, 135, 136, 137, 142, 143, 144, 146, 147, 148, 152, 130, 134, 138, 149, 150, 160, 163, 166, 22, 23, 40, 55, 171, 172, 173, 174, 175, 61, 18, 17, 187, 188, 91, 100, 115, 116, 131, 167, 168, 70, 94, 95, 108, 109, 110, 111, 118, 123, 124, 125, 126, 153, 154, 169, 170, 89, 11, 12, 13, 63, 64 }));
                        client.Connection.Send(new JobDescriptionMessage(new JobDescription[0]));
                        client.Connection.Send(new JobExperienceMultiUpdateMessage(new JobExperience[0]));
                        client.Connection.Send(new JobCrafterDirectorySettingsMessage(new JobCrafterDirectorySettings[0]));
                        client.Connection.Send(new AlignmentRankUpdateMessage(0, false));
                        client.Connection.Send(new DareCreatedListMessage(new DareInformations[0], new DareVersatileInformations[0]));
                        client.Connection.Send(new DareSubscribedListMessage(new DareInformations[0], new DareVersatileInformations[0]));
                        client.Connection.Send(new DareWonListMessage(new double[0]));
                        client.Connection.Send(new DareRewardsListMessage(new DareReward[0]));
                        client.Connection.Send(new PrismsListMessage(new PrismSubareaEmptyInfo[0]));
                        client.Connection.Send(new EnabledChannelsMessage(new byte[0], new byte[0]));
                        client.Connection.Send(new ChatCommunityChannelCommunityMessage(0));
                        client.Connection.Send(new SpellListMessage(true, client.Selected.SpellItems));
                        client.Connection.Send(new InventoryWeightMessage(client.Selected.Pods, client.Selected.MaxPods));
                        client.Connection.Send(new FriendWarnOnConnectionStateMessage(true));
                        client.Connection.Send(new FriendWarnOnLevelGainStateMessage(true));
                        client.Connection.Send(new FriendGuildWarnOnAchievementCompleteStateMessage(true));
                        client.Connection.Send(new WarnOnPermaDeathStateMessage(true));
                        client.Connection.Send(new GuildMemberWarnOnConnectionStateMessage(true));
                        client.Connection.Send(new SequenceNumberRequestMessage());
                        client.Connection.Send(new TextInformationMessage((byte)TextInformationTypeEnum.TEXT_INFORMATION_ERROR, 89, new string[0]));
                        client.Connection.Send(new OnConnectionEventMessage(2));
                        client.Connection.Send(new SpouseStatusMessage(false));
                        client.Connection.Send(new AchievementListMessage(new AchievementAchieved[0]));
                        client.Connection.Send(new GameRolePlayArenaUpdatePlayerInfosAllQueuesMessage(new ArenaRankInfos(0, 0, 0, 0, false), new ArenaRankInfos(0, 0, 0, 0, false), new ArenaRankInfos(0, 0, 0, 0, false)));
                        client.Connection.Send(new CharacterCapabilitiesMessage(4095));
                        client.Connection.Send(new AlmanachCalendarDateMessage(30));
                        client.Connection.Send(new IdolListMessage(new short[0], new short[0], new PartyIdol[0]));
                        client.Connection.Send(new CharacterExperienceGainMessage(0, 0, 0, 0));
                        client.Connection.Send(new MailStatusMessage(0, 0));
                        client.Connection.Send(new AccountHouseMessage(new AccountHouseInformations[0]));
                        client.Connection.Send(new CharacterLoadingCompleteMessage());
                        client.Connection.Send(new StartupActionsListMessage(new StartupActionAddObject[0]));
                        */
        }

        private void ProcessSelection(WorldClient client)
        {
            client.Connection.Send(new NotificationListMessage()
                             .InitNotificationListMessage(new CustomVar<int>[] { new CustomVar<int>(2147483647) }));

            client.Connection.Send(new CharacterSelectedSuccessMessage()
                             .InitCharacterSelectedSuccessMessage(client.Character.DataAccess.CharacterInformations, false));

            client.Connection.Send(new CharacterCapabilitiesMessage()
                             .InitCharacterCapabilitiesMessage(new CustomVar<int>(4095)));

            client.Connection.Send(new SequenceNumberRequestMessage());
            client.Connection.Send(new EnabledChannelsMessage()
                             .InitEnabledChannelsMessage(m_enabledChannels, new byte[0]));

            client.Connection.Send(new CharacterLoadingCompleteMessage());
        }

    }
}
