using System;
using System.Collections.Generic;

namespace projet_dot_net.Domaine
{
    public partial class Enseignant
    {
        public Enseignant()
        {
            ConventionStage = new HashSet<ConventionStage>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public virtual ICollection<ConventionStage> ConventionStage { get; set; }
    }
}
