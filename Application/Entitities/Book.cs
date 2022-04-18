using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Entitities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string CarBrand { get; set; }
        public int ModelYear{ get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public DateTime LastMaintaince { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
