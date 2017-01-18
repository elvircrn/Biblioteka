using Biblioteka;
using Biblioteka.Items;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteka.Model
{
    // XML - READY
    [Serializable]
    public class Clan : User, IClan
    {
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

        [NotMapped]
        [XmlElement, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public List<Knjiga> WishListXml { get { return WishList?.ToList() ?? new List<Knjiga>(); } set { WishList = value; } }

        public Clan()
        {
            WishList = new List<Knjiga>();
        }

        [XmlIgnore]
        [IgnoreDataMember]
        public ICollection<Record> Records { get; set; }

        [NotMapped]
        [XmlElement, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public List<Record> RecordsXml { get { return Records?.ToList() ?? new List<Record>(); } set { Records = value; } }

        public override string ToString()
        {
            return base.ToString() + Sifra + Comment;
        }
    }
}
