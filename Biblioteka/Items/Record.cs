using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Items
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }

        public int KnjigaId { get; set; }
        [ForeignKey("KnjigaId")]
        public Knjiga Knjiga { get; set; }

        public int ClanId { get; set; }
        [ForeignKey("ClanId")]
        public Clan Clan { get; set; }

        public DateTime RentDate { get; set; }

        public Knjiga Item1 { get { return Knjiga; } }

        public IClan Item2 { get { return Clan; } }

        public DateTime Item3 { get { return RentDate; }  }
    }
}
