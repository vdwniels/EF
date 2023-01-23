// See https://aka.ms/new-console-template for more information
using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Repositories;

Console.WriteLine("Hello, World!");
IHuurderRepository repo = new HuurderRepositoryEF();
BeheerHuurders behHuur = new BeheerHuurders(repo);
Contactgegevens cg1 = new Contactgegevens("Jeffry.deSmet@gmail.com", "0412345678", "Markt 5 9800 Deinze");

Contactgegevens cg2 = new Contactgegevens("Jeffery.deSmet@gmail.com", "0498765432", "Markt 15 9800 Deinze");

//behHuur.VoegNieuweHuurderToe("Jeffry", cg1);

//Huurder h = new Huurder(1002,"Jeffery", cg2);

//behHuur.UpdateHuurder(h);

//Huurder get = behHuur.GeefHuurder(1);

//Console.WriteLine(get.ToString());

//List<Huurder> huurders = behHuur.GeefHuurders("Bobbie");

//foreach(Huurder huurder in huurders)
//{
//    Console.WriteLine(huurder.ToString());
//}

IHuizenRepository repoHuis = new HuizenRepositoryEF();
BeheerHuizen behHuizen = new BeheerHuizen(repoHuis);

//Park p = new Park("100", "c", "Aalter");
//behHuizen.VoegNieuwHuisToe("teststraat2", 99, p);

Huis h = behHuizen.GeefHuis(16);
//h.ZetNr(88);
//behHuizen.UpdateHuis(h);
//behHuizen.ArchiveerHuis(h);

IContractenRepository repoContract = new ContractenRepositoryEF();
BeheerContracten behContract =  new BeheerContracten(repoContract);

//Huurperiode hp = new Huurperiode(DateTime.Today.AddDays(8), 3);

//Huis huis = repoHuis.GeefHuis(16);


    //Huurder h = repo.GeefHuurder(1);
//behContract.MaakContract("3", hp, h, huis);
//Huurcontract hc = new Huurcontract("2", hp, h, huis);
//behContract.AnnuleerContract(hc);
//behContract.UpdateContract(hc);
//Huurcontract huurcontract =  behContract.GeefContract("2");
//List<Huurcontract> list = behContract.GeefContracten(DateTime.Today.AddDays(8), DateTime.Today.AddDays(11));
Console.WriteLine("done");