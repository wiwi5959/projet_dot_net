using projet_dot_net.Domaine;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Controllers
{
    [ApiController]
    [Route("/enseignants]")]

    public class EnseignantController
    {
        public EnseignantController()
        {

        }

        public ICollection<Enseignant> findAll()
        {
            ICollection<Enseignant> enseignants = new List<Enseignant>();
            Enseignant c1 = new Enseignant()
            {
                Nom = "Vossough",
                Prenom = "Adrien"
            };
            Enseignant c2 = new Enseignant()
            {
                Nom = "Kant",
                Prenom = "Jean"
            };
            enseignants.Add(c1);
            enseignants.Add(c2);

            return enseignants;
        }
    }
}
