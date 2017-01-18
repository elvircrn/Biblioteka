using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteka.Model
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        
        public string Name { get; set; }

        public ICollection<Knjiga> Knjigas { get; set; }
    }
}