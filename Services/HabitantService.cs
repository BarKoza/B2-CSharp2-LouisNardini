using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace MyApp.Service
{
    public class HabitantService
    {
        private DemandeALutilisateur _DemandeALutilisateur;
        private CommuneService _CommuneService;
        private List<Habitants> ListeHabitants = new List<Habitants>();

        public HabitantService(DemandeALutilisateur demandeALutilisateur, CommuneService communeService)
        {
            _DemandeALutilisateur = demandeALutilisateur;
            _CommuneService = communeService;
        }

        public void AfficheHabitans(List<Habitants> Listehabitants)
        {
            Console.WriteLine("Liste des habitants créés:\n");
            foreach (Habitants h in Listehabitants)
            {
                Console.WriteLine("Nom: " + h.nom + "\n" + "Age:" + h.age + "\n");
            }
        }

        public Habitants CreateHabitants()
        {
            Habitants h = new Habitants();

            h.nom = _DemandeALutilisateur.saisieNom("Nom de l'habitant :");
            h.age = _DemandeALutilisateur.saisieEntier("Quel as tu :");

            return h;
        }

    }
}
