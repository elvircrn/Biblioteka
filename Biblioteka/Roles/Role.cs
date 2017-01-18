using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteka.Model
{
    // XML - Ready
    public class Role : Model.IRole
    {
        [Key]
        public int RoleId { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        public ICollection<User> Users { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(200)]
        public string DisplayName { get; set; }

        public Role() { }

        public Role(string Name, string DisplayName)
        {
            this.Name = Name;
            this.DisplayName = DisplayName;
        }
    }
}
