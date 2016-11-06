using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class Role : IRole
    {
        public string Name { get; set; }

        public Role() { }
        public Role(string Name)
        {
            this.Name = Name;
        }
    }
}
