using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataWeb.DbEntities
{
    [Table("info_admin")]
    public class AdminUser
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Column("account")]
        public string Account { get; set; }

        [Column("password")]
        public string Password { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("status")]
        public ushort Status { get; set; }

        public ICollection<ServerInfo> Servers { get; set; }

        public ICollection<AdminSms> Sms { get; set; }
    }
}
