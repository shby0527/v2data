using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataWeb.DbEntities
{
    [Table("info_sms")]
    public class AdminSms
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Column("code")]
        public string Code { get; set; }

        [Column("used")]
        public ushort Used { get; set; }

        [Column("adminId")]
        public uint AdminId { get; set; }

        [Column("ctime")]
        public DateTimeOffset CTime { get; set; }

        public AdminUser User { get; set; }
    }
}
