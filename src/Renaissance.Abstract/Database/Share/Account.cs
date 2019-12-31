using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Renaissance.Database.Pattern;
using Renaissance.Protocol.enums.custom;

namespace Renaissance.Abstract.Database.Share
{
    [Table("Accounts")]
    public class Account : IRecord
    {
        [Key]
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Nickname { get; set; }

        public RoleEnum Role { get; set; }

        public string SecretQuestion { get; set; }

        public string SecretAnswer { get; set; }

        public string HardwareId { get; set; }

        public byte CharactersCount { get; set; }

        public string Ticket { get; set; }

        public bool IsBanned { get; set; }

        public DateTime BanEndDate { get; set; }


        [NotMapped]
        public bool IsConnected { get; set; }

        [NotMapped]
        public bool IsAdmin => Role == RoleEnum.Administrator;

        [NotMapped]
        public bool IsLifeBanned => BanEndDate == null && IsBanned;

        [NotMapped]
        public bool CanCreateNewCharacter => CharactersCount < 5;

    }
}
