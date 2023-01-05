using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    [Table("Park")]
    public class EF_Park
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string Id { get; private set; }
        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Naam { get; private set; }
        [Column(TypeName = "nvarchar(500)")]
        public string Locatie { get; private set; }
        public  List<EF_Huis> _huis = new List<EF_Huis>() { };

        public EF_Park(string id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }

        public void AddHuis(EF_Huis h)
        {
            _huis.Add(h);
        }
    }
}
