using System;
using System.Collections.Generic;

namespace projet_dot_net.Domaine
{
    public partial class ConventionStage
    {
        public ConventionStage()
        {
            Etudiant = new HashSet<Etudiant>();
            Proposition = new HashSet<Proposition>();
        }

        public int Id { get; set; }
        public string Sujet { get; set; }
        public TimeSpan? Duree { get; set; }
        public decimal? Remuneration { get; set; }
        public int EntrepriseId { get; set; }
        public string Memoire { get; set; }
        public int EnseignantId { get; set; }

        public virtual Enseignant Enseignant { get; set; }
        public virtual Entreprise Entreprise { get; set; }
        public virtual ICollection<Etudiant> Etudiant { get; set; }
        public virtual ICollection<Proposition> Proposition { get; set; }
    }
}
