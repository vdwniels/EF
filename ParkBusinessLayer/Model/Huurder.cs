using ParkBusinessLayer.Exceptions;
using System.Collections.Generic;

namespace ParkBusinessLayer.Model
{
    public class Huurder
    {
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public Contactgegevens Contactgegevens { get; private set; }

        public Huurder(int id, string naam, Contactgegevens contactgegevens)
        {
            Id = id;
            Naam = naam;
            Contactgegevens = contactgegevens;
        }
        public Huurder(string naam, Contactgegevens contactgegevens)
        {
            Naam = naam;
            Contactgegevens = contactgegevens;
        }
    }
}