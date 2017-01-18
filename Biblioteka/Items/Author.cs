using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Biblioteka.Model
{
    // XML - Ready
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        
        public string Name { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        public ICollection<Knjiga> Knjigas { get; set; }
    }
}