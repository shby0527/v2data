using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataWeb.DbEntities
{
    [Table("info_data")]
    public class DataEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("linkType")]
        public string LinkType { get; set; }

        [Column("user")]
        public string User { get; set; }

        [Column("size")]
        public ulong Size { get; set; }

        [Column("utype")]
        public string Utype { get; set; }

        [Column("createtime")]
        public DateTime CreateTime { get; set; }
    }
}
