using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataWeb.DbEntities
{
    [Table("info_server")]
    public class ServerInfo
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }

        [Column("tags")]
        public string Tags { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("adminId")]
        public uint AdminId { get; set; }

        [Column("publicKey")]
        public string PublicKey { get; set; }

        public AdminUser Admin { get; set; }

        public ICollection<V2ServerUser> ServerUsers { get; set; }
    }
}
