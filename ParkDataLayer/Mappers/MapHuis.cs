using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public static class MapHuis
    {
        public static Huis MapNaarDomeinMetParkHuizen(EF_Huis db, List<EF_Huis> huizen,  List<Huurcontract> contracten )
        {
            try
            {
                Park p = new Park(db.Park.ParkId, db.Park.Naam, db.Park.Locatie);
                foreach (EF_Huis huis in huizen)
                {
                    huis.Park = db.Park;
                    p.VoegHuisToe(MapNaarDomein(huis));
                }
                Huis h = new Huis(db.Id,db.Straat, db.Nr,db.Actief, p);
                foreach (Huurcontract hc in contracten)
                {
                    h.VoegHuurcontractToe(hc);
                }

                return h;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapNaarDomein", ex);
            }
        }

        public static Huis MapNaarDomein(EF_Huis db, EF_Park p)
        {
            try
            {
                Park park = new Park(p.ParkId, p.Naam, p.Locatie);
                return new Huis(db.Id,db.Straat, db.Nr,db.Actief, park);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapNaarDomein", ex);
            }
        }

        public static Huis MapNaarDomein(EF_Huis db)
        {
            try
            {
                Park p = new Park(db.Park.ParkId, db.Park.Naam, db.Park.Locatie);
                return new Huis(db.Id,db.Straat, db.Nr,db.Actief, p);
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
                EF_Huis resultaat = new EF_Huis(huis.Id, huis.Straat, huis.Nr, huis.Actief, huis.Park.Id);
                resultaat.AddPark(huis.Park);
                return resultaat;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapNaarDomein", ex);
            }

        }
        public static EF_Huis MapNaarDBZonderPark(Huis huis)
        {
            try
            {
                EF_Huis resultaat = new EF_Huis(huis.Id, huis.Straat, huis.Nr, huis.Actief, huis.Park.Id);
                return resultaat;
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapNaarDomeinZonderPark", ex);
            }

        }

    }
}
