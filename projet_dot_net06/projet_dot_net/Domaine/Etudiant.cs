using System;
using System.Collections.Generic;

namespace projet_dot_net.Domaine
{
    public partial class Etudiant
    {
        public Etudiant()
        {
            Rdv = new HashSet<Rdv>();
        }

        public int Id { get; set; }
        public int ConventionStageId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public virtual ConventionStage ConventionStage { get; set; }
        public virtual ICollection<Rdv> Rdv { get; set; }
    }
}
