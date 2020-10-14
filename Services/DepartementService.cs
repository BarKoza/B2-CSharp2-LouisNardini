using MyApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Service
{
    public class DepartementService
    {
        public DemandeALutilisateur _DemandeALutilisateur;
        List<Departement> departements = new List<Departement>();

        public DepartementService(DemandeALutilisateur demandeALutilisateur)
        {
            this._DemandeALutilisateur = demandeALutilisateur;
        }

        public Departement CreeDepartement()
        {
            Departement d = new Departement();
            d.nom = _DemandeALutilisateur.saisieNom("Nom du departement");
            d.numD = _DemandeALutilisateur.saisieEntier("Numero de departement");
            departements.Add(d);
            return d;
        }

        public Departement DemandeDepartement()
        {

            Departement result = null;
            while (result == null)
            {
                int saisieUtilisateur = _DemandeALutilisateur.saisieEntier("Numéro du Département");
                foreach (Departement d in this.departements)
                {
                    if (d.numD == saisieUtilisateur)
                    {
                        result = d;
                    }


                }
            }

            return result;
        }


    }
}

