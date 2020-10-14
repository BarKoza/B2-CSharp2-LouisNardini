using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MyApp.Service
{
    public class CommuneService
    {
        private List<Commune> Communes = new List<Commune>();
        private DemandeALutilisateur _demandeALutilisateur;

        private DepartementService _departementService;

        public CommuneService(DemandeALutilisateur demandeALutilisateur, DepartementService departementService)
        {
            this._demandeALutilisateur = demandeALutilisateur;
            this._departementService = departementService;
        }

        public Commune CreerCommune()
        {
            Commune result = new Commune();

            result.Nom = _demandeALutilisateur.saisieNom("Nom de la commune :");
            result.CodePost = _demandeALutilisateur.saisieEntier(" Code postal :");
            result.NbHab = _demandeALutilisateur.saisieEntier("nombre d'habitants :");
            result.Departements = _departementService.DemandeDepartement();

            Communes.Add(result);
            return result;
        }

        public void affiche(List<Commune> Listecommunes)
        {
            Console.WriteLine("Liste des communes créées: \n");
            foreach (Commune c in Listecommunes)
            {
                var culture = CultureInfo.GetCultureInfo("en-GB");
                string nb = string.Format(culture, "{0:n0}", c.NbHab);
                nb = nb.Replace(",", ".");
                string message_p1 = "Nom: " + c.Nom + "\n" + "Code Postal: " + c.CodePost;
                string message_p2 = "Nombre d'habitants: " + nb;
                string message_p3 = "Département: " + c.Departements.nom;
                string message_p4 = "Numéro de Département: " + c.Departements.numD + "\n";
                Console.WriteLine(message_p1);
                Console.WriteLine(message_p2);
                Console.WriteLine(message_p3);
                Console.WriteLine(message_p4);
            }
        }

        public static void calculNbtotalHabs(List<Commune> listcommunes)
        {
            int Nbtot = 0;
            foreach (Commune c in listcommunes)
            {
                Nbtot = Nbtot + c.NbHab;
            }
            var culture = CultureInfo.GetCultureInfo("en-GB");
            string nb = string.Format(culture, "{0:n0}", Nbtot);
            nb = nb.Replace(",", ".");
            string message = "Nombre total d'habitants: " + nb;
            Console.WriteLine(message);
        }
    }
}


