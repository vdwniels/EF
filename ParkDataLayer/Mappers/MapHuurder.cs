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
    public static class MapHuurder
    {
        public static Huurder MapNaarDomein(EF_Huurder db)
        {
            try
            {
                return new Huurder(db.Id,db.Naam,new Contactgegevens(db.Email,db.Tel,db.Adres));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurder - MapNaarDomein", ex);
            }
        }

        public static EF_Huurder MapNaarDB(Huurder huurder)
        {
            try
            {
                
                return new EF_Huurder(huurder.Id,huurder.Naam,huurder.Contactgegevens.Email,huurder.Contactgegevens.Tel,huurder.Contactgegevens.Adres);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurder - MapNaarDomein", ex);
            }

        }

    }
}
