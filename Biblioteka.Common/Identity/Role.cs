using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Common.Identity
{
    public class Role : IRole
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }

        public Role() { }

        public Role(string Name, string DisplayName)
        {
            this.Name = Name;
            this.DisplayName = DisplayName;
        }
    }
}
