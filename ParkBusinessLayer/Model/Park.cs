using ParkBusinessLayer.Exceptions;
using System.Collections.Generic;

namespace ParkBusinessLayer.Model
{
    public class Park
    {
        public string Id { get; private set; }
        public string Naam { get; private set; }
        public string Locatie { get; private set; }
        private List<Huis> _huis =new List<Huis>(){ };

        public Park(string id, string naam, string locatie, List<Huis> huis)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
            _huis = huis;
        }
        public Park(string id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }

        public IReadOnlyList<Huis> Huizen()
        {
            return _huis.AsReadOnly();
        }
        public void VoegHuisToe(Huis huis)
        {
            if (_huis.Contains(huis)) throw new ParkException("voeghuistoe");
            _huis.Add(huis);
        }
        public void VerwijderHuis(Huis huis)
        {
            if (!_huis.Contains(huis)) throw new ParkException("verwijderhuis");
            _huis.Remove(huis);
        }
    }
}
