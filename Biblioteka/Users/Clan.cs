using Biblioteka;
using Biblioteka.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteka.Model
{
    public class Clan : User, IClan
    {
        [XmlIgnore]
        [IgnoreDataMember]
        public int ClanId { get; set; }

        public virtual double Popust
        {
            get { return 0; }
        }

        [StringLength(200)]
        public string Comment { get; set; }

        [StringLength(200)]
        public string Sifra { get; set; }

        public States State { get; set; }

        public double Cash { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        public ICollection<Knjiga> WishList { get; set; }

        public Clan()
        {
            WishList = new List<Knjiga>();
        }

        [XmlIgnore]
        [IgnoreDataMember]
        public ICollection<Record> Records { get; set; }

        public override string ToString()
        {
            return base.ToString() + Sifra + Comment;
        }
    }
}
