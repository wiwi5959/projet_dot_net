using System;
using System.Collections.Generic;

namespace projet_dot_net.Domaine
{
    public partial class Entreprise
    {
        public Entreprise()
        {
            ConventionStage = new HashSet<ConventionStage>();
            Proposition = new HashSet<Proposition>();
            Rdv = new HashSet<Rdv>();
        }

        public int Id { get; set; }
        public string Nom { get; set; }

        public virtual ICollection<ConventionStage> ConventionStage { get; set; }
        public virtual ICollection<Proposition> Proposition { get; set; }
        public virtual ICollection<Rdv> Rdv { get; set; }
    }
}
