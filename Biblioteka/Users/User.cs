using Biblioteka.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Model
{
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

        public ICollection<Role> Roles { get; set; }

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
