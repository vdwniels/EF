using System;
using System.Collections.Generic;

namespace ParkBusinessLayer.Model
{
    public class Huurcontract
    {
        public Huurcontract(string id, Huurperiode huurperiode, Huurder huurder, Huis huis)
        {
            Id = id;
            Huurperiode = huurperiode;
            Huurder = huurder;
            Huis = huis;
        }
        public string Id { get; private set; }
        public Huurperiode Huurperiode { get; private set; }
        public Huurder Huurder { get; private set; }
        public Huis Huis { get; private set; }
        public override bool Equals(object obj)
        {
            return obj is Huurcontract huurcontract &&
                   EqualityComparer<Huurperiode>.Default.Equals(Huurperiode, huurcontract.Huurperiode) &&
                   EqualityComparer<Huurder>.Default.Equals(Huurder, huurcontract.Huurder) &&
                   EqualityComparer<Huis>.Default.Equals(Huis, huurcontract.Huis);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Huurperiode, Huurder, Huis);
        }
    }
}
