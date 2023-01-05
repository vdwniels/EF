using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    [Table("HuurContract")]

    public class EF_Huurcontract
    {
        public EF_Huurcontract(string id, DateTime startDatum, DateTime eindDatum, int aantaldagen, int huurderId, EF_Huurder huurder, int huisId, EF_Huis huis)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            Aantaldagen = aantaldagen;
            HuurderId = huurderId;
            Huurder = huurder;
            HuisId = huisId;
            Huis = huis;
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

    }
}
