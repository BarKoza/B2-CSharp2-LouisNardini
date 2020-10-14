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
                string message_p2 = "Nombre d'habitants: " + nb + "\n";
                Console.WriteLine(message_p1);
                Console.WriteLine(message_p2);
            }
        }
    }
}

