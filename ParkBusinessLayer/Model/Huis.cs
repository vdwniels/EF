using ParkBusinessLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Model
{
    public class Huis
    {
        public int Id { get; private set; }
        public string Straat { get; private set; }
        public int Nr { get; private set; }
        public bool Actief { get; set; }
        public Park Park { get; private set; }
        private Dictionary<Huurder,List<Huurcontract>> _huurcontracten = new  Dictionary<Huurder, List<Huurcontract>>();

        public Huis(int id, string straat, int nr, Park park, Dictionary<Huurder, List<Huurcontract>> huurcontracten)
        {
            Id = id;
            Straat = straat;
            Nr = nr;
            Park = park;
            _huurcontracten = huurcontracten;
        }
        public Huis(string straat, int nr, Park park)
        {
            Straat = straat;
            Nr = nr;
            Park = park;
            Actief = true;
        }
        public Huis(int id, string straat, int nr, bool actief, Park park)
        {
            Id = id;
            Straat = straat;
            Nr = nr;
            Actief = actief;
            Park = park;
        }

        public IReadOnlyList<Huurcontract> Huurcontracten()
        {
            return _huurcontracten.Values.SelectMany(x=>x).ToList();
        }
        public void VoegHuurcontractToe(Huurcontract huurcontract)
        {
            if (huurcontract == null) throw new ParkException("voeghuurcontracttoe");
            if (_huurcontracten.ContainsKey(huurcontract.Huurder))
            {
                if (_huurcontracten[huurcontract.Huurder].Contains(huurcontract)) throw new ParkException("voegcontracttoe");
                _huurcontracten[huurcontract.Huurder].Add(huurcontract);
            }
            else
            {
                _huurcontracten.Add(huurcontract.Huurder, new List<Huurcontract>() { huurcontract});
            }
        }
        public void VerwijderHuurcontract(Huurcontract huurcontract)
        {
            if (huurcontract == null) throw new ParkException("verwijderhuurcontract");           
            if (_huurcontracten.ContainsKey(huurcontract.Huurder))
            {
                if (!_huurcontracten[huurcontract.Huurder].Contains(huurcontract)) throw new ParkException("verwijderhuurcontract"); 
                _huurcontracten[huurcontract.Huurder].Remove(huurcontract);
            }
            else
            {
                throw new ParkException("verwijderhuurcontract");
            }
        }
        public IReadOnlyList<Huurcontract> Huurcontracten(Huurder huurder)
        {
            if (huurder==null) throw new ParkException("huurder is null");
            if (!_huurcontracten.ContainsKey(huurder)) throw new ParkException("huurder bestaat niet");
            return _huurcontracten[huurder].AsReadOnly();
        }
        public void ZetStraat(string straat)
        {
            if (string.IsNullOrEmpty(straat)) throw new ParkException("zetstraat");
            Straat = straat;
        }
        public void ZetNr(int nr)
        {
            if (nr <= 0) throw new ParkException("zetnr");
            Nr = nr;
        }
        public void ZetContracten(Dictionary<Huurder, List<Huurcontract>> huurcontracten)
        {
            if (huurcontracten == null) throw new ParkException("zetcontracten");
            _huurcontracten = huurcontracten;
        }
    }
}
