// See https://aka.ms/new-console-template for more information
using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Repositories;

Console.WriteLine("Hello, World!");
IHuurderRepository repo = new HuurderRepositoryEF();
BeheerHuurders behHuur = new BeheerHuurders(repo);
Contactgegevens cg = new Contactgegevens("Bob.bauer@gmail.com", "0988443567", "Stationstraat 9 9800 Deinze");
behHuur.VoegNieuweHuurderToe("Bob", cg);