using System;
using System.Collections.Generic;

namespace projet_dot_net.Domaine
{
    public partial class Proposition
    {
        public int Id { get; set; }
        public TimeSpan? Duree { get; set; }
        public string Sujet { get; set; }
        public int EntrepriseId { get; set; }
        public int StageId { get; set; }

        public virtual Entreprise Entreprise { get; set; }
        public virtual ConventionStage Stage { get; set; }
    }
}
