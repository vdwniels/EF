using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ParkBusinessLayer.Model;
using ParkDataLayer.Mappers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    [Table("Huis")]

    public class EF_Huis
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get;  set; }
        [Column(TypeName = "nvarchar(250)")]
        public string Straat { get;  set; }
        [Required]
        public int Nr { get; private set; }
        [Required]
        public bool Actief { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string ParkId { get; set; }
        public EF_Park Park { get;  set; }
        private List<EF_Huurcontract> _huur = new List<EF_Huurcontract>() { };

        public EF_Huis(int id, string straat, int nr, bool actief, string parkId)
        {
            Id = id;
            Straat = straat;
            Nr = nr;
            Actief = actief;
            ParkId = parkId;
        }

        public EF_Huis(string straat, int nr, bool actief, string parkId)
        {
            Straat = straat;
            Nr = nr;
            Actief = actief;
            ParkId = parkId;
        }

        public void AddHuurcontract(EF_Huurcontract hc)
        {
            _huur.Add(hc);
        }

        public void AddPark(Park park)
        {
            EF_Park efpark = MapPark.MapNaarDB(park);
            Park = efpark;
        }
    }
}
