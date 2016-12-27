using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Users
{
    public class User
    {
        public string UserName { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string MaticniBroj { get; set; }

        public DateTime DatumRodjenja { get; set; }

        public List<IRole> Roles { get; set; }

        public string PasswordHash { get; set; }

        public User()
        {
            Roles = new List<IRole>();
        }
    }
}
