using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class MapHuurcontract
    {
        public static Huurcontract MapNaarDomein(EF_Huurcontract db, EF_Park p)
        {
            try
            {
                return new Huurcontract(db.Id,new Huurperiode(db.StartDatum,db.Aantaldagen),MapHuurder.MapNaarDomein(db.Huurder),MapHuis.MapNaarDomein(db.Huis, p));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurder - MapNaarDomein", ex);
            }
        }

        public static EF_Huurcontract MapNaarDB(Huurcontract huurcontract)
        {
            try
            {
                EF_Huurcontract resultaat = new EF_Huurcontract(huurcontract.Id, huurcontract.Huurperiode.StartDatum, huurcontract.Huurperiode.EindDatum, huurcontract.Huurperiode.Aantaldagen, huurcontract.Huurder.Id, huurcontract.Huis.Id);
                resultaat.AddHuis(huurcontract.Huis);
                resultaat.AddHuurder(huurcontract.Huurder);
                return resultaat;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurder - MapNaarDomein", ex);
            }

        }

    }
}
