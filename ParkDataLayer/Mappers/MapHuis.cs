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
    public static class MapHuis
    {
        public static Huis MapNaarDomein(EF_Huis db)
        {
            try
            {
                return new Huis(db.Straat, db.Nr, new Park(db.Park.Id, db.Park.Naam, db.Park.Locatie));
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapNaarDomein", ex);
            }
        }

        public static EF_Huis MapNaarDB(Huis huis)
        {
            try
            {
                EF_Park parkEF = MapPark.MapNaarDB(huis.Park);
                return new EF_Huis(huis.Id,huis.Straat,huis.Nr,huis.Actief,huis.Park.Id,parkEF);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapNaarDomein", ex);
            }

        }
    }
}
