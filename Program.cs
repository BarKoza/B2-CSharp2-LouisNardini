using System;
using System.Collections.Generic;
using System.Globalization;
using MyApp.Model;
using MyApp.Service;
namespace MyApp
{
    class Program
    {
        private static DemandeALutilisateur _DemandeALutilisateur = new DemandeALutilisateur();
        static void Main(string[] args)
        {
            DemandeALutilisateur _DemandeALutilisateur = new DemandeALutilisateur();
            DepartementService _DepartementService = new DepartementService(_DemandeALutilisateur);
            CommuneService _CommuneService = new CommuneService(_DemandeALutilisateur, _DepartementService);
            HabitantService _HabitantService = new HabitantService(_DemandeALutilisateur, _CommuneService);



            List<Commune> listcommune = new List<Commune>();
            List<Habitants> listhabitants = new List<Habitants>();

            while (true)
            {
                string choixUtilisateur = MenuUtilisateur();

                if (choixUtilisateur == "1")
                {
                    Habitants h = _HabitantService.CreateHabitants();
                    listhabitants.Add(h);

                }
                else if (choixUtilisateur == "2")
                {
                    _HabitantService.AfficheHabitans(listhabitants);
                }
                else if (choixUtilisateur == "3")
                {
                    Commune c = _CommuneService.CreerCommune();
                    listcommune.Add(c);
                }
                else if (choixUtilisateur == "4")
                {
                    _DepartementService.CreeDepartement();
                }
                else if (choixUtilisateur == "5")
                {
                    _CommuneService.affiche(listcommune);
                }
                else if (choixUtilisateur == "Q")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Je n'ai pas compris");
                }
            }
        }

        private static string MenuUtilisateur()
        {
            Console.WriteLine("Que voulez-vous faire ?");
            Console.WriteLine("1. Créer un habitant");
            Console.WriteLine("2. Afficher la liste des habitants");
            Console.WriteLine("3. Créer une Commune");
            Console.WriteLine("4. Creer un département");
            Console.WriteLine("5. Afficher la liste des Communes");
            Console.WriteLine("Q. Quitter");
            string choix = Console.ReadLine();
            return choix;
        }


    }
}

