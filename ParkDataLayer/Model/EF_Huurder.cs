using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    [Table("Huurder")]

    public class EF_Huurder
    {
        public EF_Huurder(int id, string naam, string email, string tel, string adres)
        {
            Id = id;
            Naam = naam;
            Email = email;
            Tel = tel;
            Adres = adres;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }
        [Required, Column(TypeName = "nvarchar(100)")]
        public string Naam { get; private set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Tel { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Adres { get; set; }

    }
}
