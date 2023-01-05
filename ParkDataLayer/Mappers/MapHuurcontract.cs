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
        public static Huurcontract MapNaarDomein(EF_Huurcontract db)
        {
            try
            {
                return new Huurcontract(db.Id,new Huurperiode(db.StartDatum,db.Aantaldagen),MapHuurder.MapNaarDomein(db.Huurder),MapHuis.MapNaarDomein(db.Huis));
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

                return new EF_Huurcontract(huurcontract.Id,huurcontract.Huurperiode.StartDatum,huurcontract.Huurperiode.EindDatum,huurcontract.Huurperiode.Aantaldagen,huurcontract.Huurder.Id,MapHuurder.MapNaarDB(huurcontract.Huurder),huurcontract.Huis.Id,MapHuis.MapNaarDB(huurcontract.Huis));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurder - MapNaarDomein", ex);
            }

        }

    }
}
