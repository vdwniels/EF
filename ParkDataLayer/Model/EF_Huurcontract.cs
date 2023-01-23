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
    [Table("HuurContract")]

    public class EF_Huurcontract
    {
        public EF_Huurcontract(string id, DateTime startDatum, DateTime eindDatum, int aantaldagen, int huurderId, int huisId)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Aantaldagen = aantaldagen;
            HuurderId = huurderId;
            HuisId = huisId;
        }

        [Key]
        [Column(TypeName = "nvarchar(25)")]
        public string Id { get; private set; }
        [Required]
        public DateTime StartDatum { get; set; }
        [Required]
        public DateTime EindDatum { get; set; }
        [Required]
        public int Aantaldagen { get; set; }
        public int HuurderId { get; set; }
        public EF_Huurder Huurder { get; private set; }
        public int HuisId { get; set; }
        public EF_Huis Huis { get; private set; }

        public void AddHuurder(Huurder huurder)
        {
            EF_Huurder efhuurder = MapHuurder.MapNaarDB(huurder);
            Huurder = efhuurder;
        }

        public void AddHuis(Huis huis)
        {
            EF_Huis efhuis = MapHuis.MapNaarDBZonderPark(huis);
            Huis = efhuis;
        }

    }
}
