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
    public static class MapPark
    {
        public static Park MapNaarDomein(EF_Park db)
        {
            try
            {
                Park p = new Park(db.ParkId, db.Naam, db.Locatie);
                foreach (EF_Huis hdb in db._huis)
                {
                    Huis h = MapHuis.MapNaarDomein(hdb);
                    p.VoegHuisToe(h);
                }
                return p;
            }
            catch (Exception ex)
            {
                throw new MapperException("Mappark - MapNaarDomein", ex);
            }
        }

        public static EF_Park MapNaarDB(Park park)
        {
            try
            {
                EF_Park parkEF = new EF_Park(park.Id, park.Naam, park.Locatie);
                return parkEF;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapNaarDomein", ex);
            }

        }

    }
}
