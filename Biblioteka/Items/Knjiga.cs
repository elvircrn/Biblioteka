using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using System.ComponentModel.DataAnnotations;
using Biblioteka.Items;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Biblioteka.Model
{
    public class Knjiga
    {
        public int KnjigaId { get; set; }

        [StringLength(200)]
        public string Naslov { get; set; }

        public ICollection<Author> SpisakAutora { get; set; }

        [StringLength(200)]
        public string Sifra { get; set; }

        [StringLength(200)]
        public string Zanr { get; set; }

        // Rent
        [XmlIgnore]
        [IgnoreDataMember]
        public ICollection<Record> Records { get; set; }

        public int GodinaIzdanja { get; set; }

        [StringLength(200)]
        public string ISBN { get; set; }

        public bool Taken { get; set; }

        // Wishlist
        [XmlIgnore]
        [IgnoreDataMember]
        public ICollection<Clan> Clans { get; set; }

        public override string ToString()
        {
            string ret = "";
            ret += Naslov;
            foreach (var autor in SpisakAutora ?? new List<Author>())
                ret += autor.Name;
            ret += Zanr;
            ret += ISBN;
            return ret;
        }
    }
}
