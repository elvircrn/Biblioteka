using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteka.Model
{
    // XML - READY
    // Binary - NOT READY
    public class User
    {
        public int UserId { get; set; }

        [StringLength(200)]
        public string UserName { get; set; }

        [StringLength(200)]
        public string Ime { get; set; }

        [StringLength(200)]
        public string Prezime { get; set; }

        [StringLength(200)]
        public string MaticniBroj { get; set; }

        public DateTime DatumRodjenja { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        public ICollection<Role> Roles { get; set; }

        [NotMapped]
        [XmlElement, Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public List<Role> RolesXml { get { return Roles?.ToList() ?? new List<Role>(); } set { Roles = value; } }

        [StringLength(200)]
        public string PasswordHash { get; set; }
        
        [StringLength(200)]
        public string Email { get; set; }

        public override string ToString()
        {
            return Ime + Prezime + Email + MaticniBroj;
        }
    }
}
