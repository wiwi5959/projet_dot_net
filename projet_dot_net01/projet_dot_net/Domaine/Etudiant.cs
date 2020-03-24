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
        public int StageId { get; set; }

        public virtual ConventionStage Stage { get; set; }
        public virtual ICollection<Rdv> Rdv { get; set; }
    }
}
