using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private HuurContext ctx = new HuurContext();

        public Huurder GeefHuurder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateHuurder(Huurder huurder)
        {
            throw new NotImplementedException();
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
