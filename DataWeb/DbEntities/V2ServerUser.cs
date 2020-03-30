using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataWeb.DbEntities
{
    [Table("info_v2user")]
    public class V2ServerUser
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("account")]
        public string Account { get; set; }

        [Column("alterId")]
        public uint AlterId { get; set; }

        [Column("level")]
        public uint Level { get; set; }

        [Column("disabled")]
        public int Disabled { get; set; }

        [Column("serverId")]
        public uint ServerId { get; set; }

        public ServerInfo Server { get; set; }
    }
}
