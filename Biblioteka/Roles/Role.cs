using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Role : Model.IRole
    {
        [Key]
        public int RoleId { get; set; }

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
