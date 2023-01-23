using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private HuurContext ctx = new HuurContext();

        public Huis GeefHuis(int id)
        {
            try
            {
                EF_Park p = GeefPark(id);
                List<EF_Huis> huizen = ctx.Huis.Where(x => x.ParkId == p.ParkId).AsNoTracking().ToList();
                //Dictionary<Huurder, List<Huurcontract>> huurcontracten = new Dictionary<Huurder, List<Huurcontract>>();
                //List<Huurder> huurders = ctx.Huurcontract.Where(x => x.HuisId == id).AsNoTracking().Select(x => MapHuurder.MapNaarDomein(x.Huurder)).ToList();

                //foreach(Huurder h in huurders)
                //{
                //    List<Huurcontract> contracten = ctx.Huurcontract.Where(x => x.HuurderId == h.Id).AsNoTracking().Select(x => MapHuurcontract.MapNaarDomein(x)).ToList();
                //    huurcontracten.Add(h, contracten);
                //}
                List<Huurcontract> contracten = ctx.Huurcontract.Where(x => x.HuisId == id).Include(x => x.Huurder).Include(x => x.Huis).AsNoTracking().Select(x => MapHuurcontract.MapNaarDomein(x,p)).ToList();

                return MapHuis.MapNaarDomeinMetParkHuizen(ctx.Huis.Where(x => x.Id == id).Include(x => x.Park).AsNoTracking().FirstOrDefault(), huizen,contracten);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefHuurder", ex);
            }
        }

        private EF_Park GeefPark(int id)
        {
            try
            {
                return ctx.Huis.Where(x => x.Id == id).Select(x => x.Park).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefHuurder", ex);
            }

        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try
            {
                return ctx.Huis.Any(x => x.Straat == straat && x.Nr == nummer && x.Park.ParkId == park.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool HeeftHuis(int id)
        {
            try
            {
                return ctx.Huis.Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftHuis");
            }
        }

        public void UpdateHuis(Huis huis)
        {
            try
            {
                ctx.Huis.Update(MapHuis.MapNaarDB(huis));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("UpdateHuis", ex);
            }
        }

        public Huis VoegHuisToe(Huis h)
        {
            try
            {
                EF_Huis huis = MapHuis.MapNaarDB(h);
               
                ctx.Huis.Add(huis);
                ctx.SaveChanges();
                return MapHuis.MapNaarDomein(ctx.Huis.Where(x => x.Straat == h.Straat && x.Nr == h.Nr && x.Park.ParkId == h.Park.Id).Include(x => x.Park).AsNoTracking().FirstOrDefault());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
