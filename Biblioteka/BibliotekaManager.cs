using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
    public class BibliotekaManager
    {
        private static readonly double BachelorPopust = 10.0;
        private static readonly double MasterPopust = 12.5;
        private static readonly double ProfesorPopust = 15.0;

        private ClanManager _clanManager;
        private RoleManager<Role> _roleManager;
        

        private void Init()
        {
            _clanManager = new ClanManager();
            _roleManager = new RoleManager<Role>();

            _roleManager.AddRole(new Role("BACHELOR"));
            _roleManager.AddRole(new Role("MASTER"));
            _roleManager.AddRole(new Role("PROFESOR"));
        }

        public string Ime { get; set; }

        public BibliotekaManager(string Ime)
        {
            this.Ime = Ime;
            Init();
        }
    }
}
