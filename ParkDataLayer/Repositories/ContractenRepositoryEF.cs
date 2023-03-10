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
    public class ContractenRepositoryEF : IContractenRepository
    {
        private HuurContext ctx = new HuurContext();
        public void AnnuleerContract(Huurcontract contract)
        {
            try
            {
                ctx.Huurcontract.Remove(MapHuurcontract.MapNaarDB(contract));
                ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new RepositoryException("AnnuleerContract", ex);
            }
        }

        public Huurcontract GeefContract(string id)
        {
            try
            {
                return MapHuurcontract.MapNaarDomein(ctx.Huurcontract.Where(x => x.Id == id).Include(x => x.Huurder).Include(x => x.Huis).Include(x => x.Huis.Park).AsNoTracking().FirstOrDefault(), ctx.Huurcontract.Where(x => x.Id == id).Select(x => x.Huis.Park).AsNoTracking().FirstOrDefault());
            }
            catch(Exception ex)
            {
                throw new RepositoryException("GeefContract");
            } 
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            try
            {
                if (!dtEinde.HasValue)
                {
                    return ctx.Huurcontract.Where(x => x.StartDatum >= dtBegin).AsNoTracking().Include(x => x.Huurder).Include(x => x.Huis).Include(x => x.Huis.Park).Select(x => MapHuurcontract.MapNaarDomein(x,x.Huis.Park)).ToList();
                }
                else return ctx.Huurcontract.Where(x => x.StartDatum >= dtBegin && x.EindDatum<= dtEinde).AsNoTracking().Include(x => x.Huurder).Include(x => x.Huis).Include(x => x.Huis.Park).Select(x => MapHuurcontract.MapNaarDomein(x, x.Huis.Park)).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefContracten");
            }

        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try
            {
                return ctx.Huurcontract.Any(x => x.HuurderId == huurderid && x.HuisId == huisid && x.StartDatum == startDatum);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftContract");
            }
        }

        public bool HeeftContract(string id)
        {
            try
            {
                return ctx.Huurcontract.Any(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftContract");
            }
        }

        public void UpdateContract(Huurcontract contract)
        {
            try
            {
                ctx.Huurcontract.Update(MapHuurcontract.MapNaarDB(contract));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("UpdateGemeente", ex);
            }
        }

        public void VoegContractToe(Huurcontract contract)
        {
            try
            {
                ctx.Huurcontract.Add(MapHuurcontract.MapNaarDB(contract));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("VoegContractToe");
            }
        }
    }
}
