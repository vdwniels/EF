using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private HuurContext ctx = new HuurContext();

        public Huurder GeefHuurder(int id)
        {
            try
            {
                return MapHuurder.MapNaarDomein(ctx.Huurder.Where(x => x.Id == id).AsNoTracking().FirstOrDefault());
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefHuurder", ex);
            }
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                return ctx.Huurder.Where(x => x.Naam == naam).AsNoTracking().Select(x => MapHuurder.MapNaarDomein(x)).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefGemeenten", ex);
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            try
            {
                return ctx.Huurder.Any(x=>x.Naam==naam && x.Adres == contact.Adres && x.Email == contact.Email && x.Tel == contact.Tel);
            }
            catch(Exception ex)
            {
                throw new RepositoryException("HeeftHuurder");
            }
        }

        public bool HeeftHuurder(int id)
        {
            try
            {
                return ctx.Huurder.Any(x => x.Id==id);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("HeeftHuurder");
            }
        }

        public void UpdateHuurder(Huurder huurder)
        {
            try
            {
                ctx.Huurder.Update(MapHuurder.MapNaarDB(huurder));
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("UpdateHuurder", ex);
            }
        }

        public Huurder VoegHuurderToe(Huurder h)
        {
            try
            {
                ctx.Huurder.Add(MapHuurder.MapNaarDB(h));
                ctx.SaveChanges();
                return h;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("VoegHuurderToe");
            }
        }
    }
}
