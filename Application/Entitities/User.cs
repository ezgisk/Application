using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Entitities
{
    
        public class User
        {
            [Key]
            public int Id { get; set; }
            public string UserName{ get; set; }
            [MaxLength(250)]
            public string FirstName { get; set; }
            [MaxLength(500)]
            public string Lastname { get; set; }
            public string LastName { get; internal set; }
            public string Description{ get; set; }
            public List<Book> Books { get; set; }

    }
    
}
